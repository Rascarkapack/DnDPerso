﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoBLL.Base;
using DnDPersoEntities;
using DnDPersoEntities.Entities;
using DnDPersoDAL;

namespace DnDPersoBLL
{
    public class PouvoirBLL : BaseBLL<Pouvoir>
    {
        public static string GetListePouvoir(FilterPouvoir model)
        {
            return PouvoirDAL.GetListePouvoir(model);
        }
    }
}
