﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCSHARP.Data;
using ATCSHARP.Models;

namespace ATCSHARP.Pages.Pacotes
{
    public class DetailsModel : PageModel
    {
        private readonly ATCSHARP.Data.ApplicationDbContext _context;

        public DetailsModel(ATCSHARP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.Pacotes.FirstOrDefaultAsync(m => m.Id == id);
            if (pacoteturistico == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristico = pacoteturistico;
            }
            return Page();
        }
    }
}
