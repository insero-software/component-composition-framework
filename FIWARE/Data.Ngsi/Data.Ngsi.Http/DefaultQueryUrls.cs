﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIWARE.Data.Ngsi.Http.Extensions;

namespace FIWARE.Data.Ngsi.Http
{
   public static class DefaultQueryUrls
   {
      public static string GetQueryContext( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI10/queryContext" ).ToString();
      }

      public static string GetSubscribeContext( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI10/subscribeContext" ).ToString();
      }

      public static string GetUpdateContextSubscription( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI10/updateContextSubscription" ).ToString();
      }

      public static string GetUnsubscribeContext( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI10/unsubscribeContext" ).ToString();
      }

      public static string GetUpdateContext( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI10/updateContext" ).ToString();
      }

      public static string GetDiscoverContextAvailability( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI9/discoverContextAvailability" ).ToString();
      }

      public static string GetRegisterContext( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI9/registerContext" ).ToString();
      }

      public static string GetSubscribeContextAvailability( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI9/subscribeContextAvailability" ).ToString();
      }

      public static string GetUnsubscribeContextAvailability( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI9/unsubscribeContextAvailability" ).ToString();
      }

      public static string GetUpdateContextAvailabilitySubscription( string baseUrl )
      {
         return new Uri( baseUrl ).Append( "NGSI9/updateContextAvailabilitySubscription" ).ToString();
      }
   }
}
