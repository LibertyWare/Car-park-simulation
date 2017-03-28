﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class Barrier
    {
        private bool lifted;
        public Barrier()
        {
            lifted = false;
        }
        public bool IsLifted()
        {
            return lifted;
        }
        public void Lower()
        {
            lifted = false;
        }
        public void Raise()
        {
            lifted = true;
        }
    }
}