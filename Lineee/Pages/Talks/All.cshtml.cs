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
    public class AllModel : PageModel
    {
        private readonly AccountContext _accContext;
        private readonly TalkContext _talkContext;

        public IList<Account> AccountList { get; set; }
        public Account MyAccount { get; set; }
        public Dictionary<Account, string> LastTalk { get; set; }

        private int myid;

        public AllModel(AccountContext accountContext, TalkContext talkContext)
        {
            _accContext = accountContext;
            _talkContext = talkContext;
        }
        
        [HttpGet("{id}")]
        public async Task OnGetAsync(int id)
        {
            myid = id;
            MyAccount = await _accContext.Account.FindAsync(id);
            AccountList = await _accContext.Account.ToListAsync();
            LastTalk = new Dictionary<Account, string>();
            //register last post to "LastTalk"
            foreach(Account acc in AccountList)
            {
                var lt = await _talkContext.Talk.LastOrDefaultAsync(talk => 
                    (talk.FromNameID == myid && talk.ToNameID == acc.ID) || 
                    (talk.ToNameID == myid && talk.FromNameID == acc.ID) );
                LastTalk.Add(acc, (lt != null) ? lt.Message : "（まだメッセージがありません）");
            }
        }
    }
}