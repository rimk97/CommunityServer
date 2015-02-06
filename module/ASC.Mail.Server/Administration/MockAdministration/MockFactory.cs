/*
 * 
 * (c) Copyright Ascensio System SIA 2010-2014
 * 
 * This program is a free software product.
 * You can redistribute it and/or modify it under the terms of the GNU Affero General Public License
 * (AGPL) version 3 as published by the Free Software Foundation. 
 * In accordance with Section 7(a) of the GNU AGPL its Section 15 shall be amended to the effect 
 * that Ascensio System SIA expressly excludes the warranty of non-infringement of any third-party rights.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * For details, see the GNU AGPL at: http://www.gnu.org/licenses/agpl-3.0.html
 * 
 * You can contact Ascensio System SIA at Lubanas st. 125a-25, Riga, Latvia, EU, LV-1021.
 * 
 * The interactive user interfaces in modified source and object code versions of the Program 
 * must display Appropriate Legal Notices, as required under Section 5 of the GNU AGPL version 3.
 * 
 * Pursuant to Section 7(b) of the License you must retain the original Product logo when distributing the program. 
 * Pursuant to Section 7(e) we decline to grant you any rights under trademark law for use of our trademarks.
 * 
 * All the Product's GUI elements, including illustrations and icon sets, as well as technical 
 * writing content are licensed under the terms of the Creative Commons Attribution-ShareAlike 4.0 International. 
 * See the License terms at http://creativecommons.org/licenses/by-sa/4.0/legalcode
 * 
*/

using System.Collections.Generic;
using ASC.Common.Security.Authentication;
using ASC.Mail.Aggregator.Common.Logging;
using ASC.Mail.Server.Administration.Interfaces;
using ASC.Mail.Server.Administration.ServerModel;

namespace ASC.Mail.Server.MockAdministration
{
    public class MockFactory : MailServerFactoryBase
    {
        public override MailServerBase CreateServer(ServerSetup setup)
        {
            return new MockServer(setup);
        }

        public override IMailAddress CreateMailAddress(int id, int tenant, string name, IWebDomain domain)
        {
            return new MockAddress(id, tenant, name, domain);
        }

        public override IWebDomain CreateWebDomain(int id, int tenant, string name, bool is_verified, MailServerBase server)
        {
            return new MockDomain(id, tenant, name, is_verified, server);
        }


        public override IMailbox CreateMailbox(int id, int tenant, IMailAddress address, IMailAccount account, List<IMailAddress> aliases, MailServerBase server)
        {
            return new MockMailbox(id, tenant, address, account, aliases, server);
        }

        public override IMailGroup CreateMailGroup(int id, int tenant, IMailAddress address, List<IMailAddress> in_addresses, MailServerBase server)
        {
            return new MockMailGroup(id, tenant, address, in_addresses, server);
        }

        public override IMailAccount CreateMailAccount(IAccount teamlab_account, string login)
        {
            return new MockAccount(teamlab_account, login);
        }

        public override IDnsSettings CreateDnsSettings(int id, int tenant, string user, string domain_name, string dkim_selector, string dkim_private_key,
                                string dkim_public_key, string domain_check_name, string domain_check_record,
                                string spf_name, string spf_record, string mx_host, int mx_priority, ILogger logger = null)
        {
            return new MockDnsSettings(id, tenant, user, domain_name, dkim_selector, dkim_private_key, dkim_public_key, domain_check_name,
            domain_check_record, spf_name, spf_record, mx_host, mx_priority, logger);
        }
    }
}