﻿using Edura.Domain.Entity.Common;
using Edura.Model.SearchCriteria.Common;
using Edura.Orchestrator.Common.Contract;
using Edura.Repository.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edura.Orchestrator.Common
{
    public class DetailCodeOrch: IDetailCodeOrch
    {
        private IDetailCodeRepository detailCodeRepository;

        public DetailCodeOrch(IDetailCodeRepository _detailCodeRepository)
        {
            detailCodeRepository = _detailCodeRepository;
        }

        

       
    }
}