﻿using System;

namespace SlothEnterprise.ProductApplication.Interfaces
{
    public interface ISellerCompanyData
    {
        string Name { get; set; }
        int Number { get; set; }
        string DirectorName { get; set; }
        DateTime Founded { get; set; }
    }
}
