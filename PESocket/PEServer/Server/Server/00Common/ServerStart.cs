﻿using System;
using System.Text.RegularExpressions;

public class ServerStart
{
    static void Main(string[] args)
    {
        ServerRoot.Instance.Init();

        while (true)
        {
            ServerRoot.Instance.Update();
        }
    }
}

