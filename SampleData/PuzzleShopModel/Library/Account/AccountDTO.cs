using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Library.Account
{

    class AccountDTO
    {
        public ObjectId _id { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int role { get; set; }
    }

}
