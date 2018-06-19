using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lineee.Models;

namespace Lineee.Pages.Talks
{
    public class RoomModel : PageModel
    {
        private readonly AccountContext _accContext;
        private readonly TalkContext _talkContext;

        //public IList<Talk> TalkList { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public Account MyAccount { get; set; }
        public Account ToAccount { get; set; }
        
        [BindProperty]
        public Talk NewTalk { get; set; }

        public RoomModel(AccountContext accountContext, TalkContext talkContext)
        {
            _accContext = accountContext;
            _talkContext = talkContext;
        }

        [HttpGet("{myid}/{toid}")]
        public async Task OnGetAsync(int myid, int toid)
        {
            MyAccount = await _accContext.Account.FindAsync(myid);
            ToAccount = await _accContext.Account.FindAsync(toid);
            Talks = _talkContext.Talk;
        }

        public async Task<IActionResult> OnPostAsync(int myid, int toid)
        {
            await _talkContext.AddAsync(new Talk()
            {
                FromNameID = myid,
                ToNameID = toid,
                Message = NewTalk.Message,
                DateTime = DateTime.Now
            });
            
            await _talkContext.SaveChangesAsync();
            NewTalk.Message = "";
            return RedirectToPage("./Room", new { myid = myid, toid = toid });
        }
    }
}