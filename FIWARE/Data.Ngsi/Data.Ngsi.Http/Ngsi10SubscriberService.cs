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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using FIWARE.Data.Ngsi.Http.Extensions;
using FIWARE.Data.Ngsi.Http.Internal;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using Owin;

namespace FIWARE.Data.Ngsi.Http
{
   public class Ngsi10SubscriberService : IDisposable
   {
      private IDisposable _service;
      private IIncomingSubscriberOperations _clientOperation;
      private string _baseAddress;
      private bool _disposed;

      public Ngsi10SubscriberService( string baseAddress, IIncomingSubscriberOperations clientOperations )
      {
         _baseAddress = baseAddress;
         _clientOperation = clientOperations;
      }

      public string NotifyAddress
      {
         get
         {
            return _baseAddress;
         }
      }

      public void Start()
      {
         Stop();

         // Setup web service
         _service = WebApp.Start(
            url: _baseAddress,
            startup: builder =>
            {
               var config = new HttpConfiguration();
               config.Routes.MapHttpRoute(
                  "NGSI Client API",
                  "",
                  new { controller = "ngsi10subscriber" } );
               config.Formatters.XmlFormatter.UseXmlSerializer = true;

               var container = new UnityContainer();
               container.RegisterType<Ngsi10SubscriberController>( new InjectionConstructor( _clientOperation ) );
               config.DependencyResolver = new UnityDependencyResolver( container );
               config.Services.Replace(
                  typeof( IAssembliesResolver ),
                  new SingleAssemblyResolver( Assembly.GetExecutingAssembly() ) );

               builder.UseWebApi( config );
            } );
      }

      public void Stop()
      {
         if ( _service != null )
         {
            _service.Dispose();
            _service = null;
         }
      }

      #region IDisposable Members

      ~Ngsi10SubscriberService()
      {
         Dispose( false );
      }

      public void Dispose()
      {
         if ( !_disposed )
         {
            Dispose( true );
            GC.SuppressFinalize( this );
            _disposed = true;
         }
      }

      private void Dispose( bool disposing )
      {
         if ( disposing )
         {
            Stop();
         }
      }

      #endregion
   }
}
