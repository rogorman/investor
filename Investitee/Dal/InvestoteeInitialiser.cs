﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Investitee.Dal
{
    public class InvestoteeInitialiser : DropCreateDatabaseIfModelChanges<InvestiteeContext>
    {

    }
}