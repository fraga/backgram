﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Core.Api
{
    public interface IInstagramAuthRestfulEndpoint: IInstagramRestfulEndpoint
    {
        string AccessToken { get; set; }
    }
}