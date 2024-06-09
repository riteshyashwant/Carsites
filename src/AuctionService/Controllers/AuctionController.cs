using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AuctionService.Controllers;

    [ApiController]
    [Route("api/auctions")]
    public class AuctionController : ControllerBase
{
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;

        public AuctionController(AuctionDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

[HttpGet]
public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
        {
            var auction = await _context.Auctions
           .Include(x=> x.Item)
           .OrderBy(x=>x.Item.Make)
           .ToListAsync();
           return _mapper.Map<List<AuctionDto>>(auction);  
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid Id)
        {
            var auction = await _context.Auctions
           .Include(x=> x.Item)
           .FirstOrDefaultAsync(x=> x.ID == Id);

           if(auction == null) return NotFound();
           return _mapper.Map<AuctionDto>(auction);  
        }

        [HttpPost]
        public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto auctionDto)
        {
             var auction = _mapper.Map<Auction>(auctionDto);
             auction.Seller= "test";

             _context.Auctions.Add(auction);

             var result = await _context.SaveChangesAsync()> 0;
            if(!result) return BadRequest("Could not save data in DB.");
            return CreatedAtAction(nameof(GetAuctionById), new{auction.ID}, _mapper.Map<AuctionDto>(auction));
        }

         [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDto updateauctionDto)
        {
             var auction = _context.Auctions.Include(x=> x.Item)
             .FirstOrDefaultAsync(x=> x.ID==id);
             if(auction == null) return NotFound();
             auction.Result.Item.Make = updateauctionDto.Make ?? auction.Result.Item.Make;
              auction.Result.Item.Model = updateauctionDto.Model ?? auction.Result.Item.Model;
               auction.Result.Item.Color = updateauctionDto.Color ?? auction.Result.Item.Color;
                auction.Result.Item.Milage = updateauctionDto.Milage ?? auction.Result.Item.Milage;
                 auction.Result.Item.Year = updateauctionDto.Year ?? auction.Result.Item.Year;
            var result = await _context.SaveChangesAsync() >0;
            if(result) return Ok();
            return BadRequest("Problem saving data0");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuction(Guid id)
        {
             var auction = await _context.Auctions.FindAsync(id);
             if(auction == null) return NotFound();

             _context.Auctions.Remove(auction);
             var result = await _context.SaveChangesAsync() >0;
             if(!result) return BadRequest("Id not found");
             return Ok();


        }
    }