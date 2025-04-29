﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookCategoryRelation> Books { get; set; }
    }
}
