﻿using System.Collections.Generic;
 
 public static class ListExtenstion
 {
     public static void AddMany<T>(this List<T> list, params T[] elements)
     {
         list.AddRange(elements);
     }
 }