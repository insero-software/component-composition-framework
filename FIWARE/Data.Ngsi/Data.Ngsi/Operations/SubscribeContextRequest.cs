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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FIWARE.Data.Ngsi.Model;

namespace FIWARE.Data.Ngsi.Operations
{
   [XmlRoot( "subscribeContextRequest" )]
   public class SubscribeContextRequest
   {
      /// <summary>
      /// List of identifiers of the Context Entity(ies) for which the 
      /// Context Information is requested. 
      /// Identifier can contain patterns represented as regular 
      /// expressions. 
      /// </summary>
      [XmlArray( "entityIdList" )]
      [XmlArrayItem( "entityId" )]
      public List<EntityID> EntityIDs { get; set; }

      /// <summary>
      /// List of ContextAttributes and/or AttributeDomains to which 
      /// the requestor wants to subscribe.
      /// </summary>
      [XmlArray( "attributeList" )]
      [XmlArrayItem( "attribute" )]
      public List<string> Attributes { get; set; }

      /// <summary>
      /// URI that identifies the interface where the notifyContext 
      /// operation SHALL be invoked. 
      /// </summary>
      [XmlElement( "reference", DataType = "anyURI" )]
      public string Reference { get; set; }

      /// <summary>
      /// Requested duration of the subscription. Negative values 
      /// SHALL result in an error. 
      /// If the Context Management component has a policy to 
      /// always require duration, the operation SHALL return an error 
      /// in case the parameter is not present. 
      /// If the parameter is omitted, the Context Management 
      /// component MAY select a duration and return this in the 
      /// response.
      /// </summary>
      [XmlElement( "duration", Type = typeof( XmlTimeSpan ) )]
      public TimeSpan? Duration { get; set; }

      /// <summary>
      /// Restriction on the attributes and meta-data of the Context 
      /// Information 
      /// </summary>
      [XmlElement( "restriction" )]
      public Restriction Restriction { get; set; }

      /// <summary>
      /// Conditions when to send the notifications.
      /// </summary>
      [XmlArray( "notifyConditions" )]
      [XmlArrayItem( "notifyCondition" )]
      public List<NotifyCondition> NotifyConditions { get; set; }

      /// <summary>
      /// Proposed minimum interval between notifications.
      /// </summary>
      [XmlElement( "throttling", Type = typeof( XmlTimeSpan ) )]
      public TimeSpan? Throttling { get; set; }

      public void Update( UpdateContextSubscriptionRequest update )
      {
         Restriction = update.Restriction;
         NotifyConditions = update.NotifyConditions;
         Throttling = update.Throttling;
         Duration = update.Duration;
      }
   }
}
