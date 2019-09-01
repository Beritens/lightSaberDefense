     using UnityEngine;
     using System.Collections;
     using System;
     using System.Collections.Generic;
     
     public static class ArrayExtension
     {
         public static bool ArrContains<T>(this T[] theArr, T target)
         {
             bool retVal = false;
     
             for (int xx = 0; xx < theArr.Length; xx++) {
                 if(EqualityComparer<T>.Default.Equals(theArr[xx], target))
                 {
                     retVal = true;
                     break;
                 }
             }
             return retVal;
         }
     }
