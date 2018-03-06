﻿using System;
using AutoFixture.NUnit3;
using HubSpot.Contacts;
using HubSpot.Contacts.Selectors;
using NUnit.Framework;

namespace Tests.Contacts
{
    [TestFixture]
    public class SelectContactTests
    {
        [Test, AutoData]
        public void ByEmail_returns_proper_selector(string email)
        {
            Assert.That(SelectContact.ByEmail(email), Is.InstanceOf<EmailContactSelector>());
        }

        [Test, AutoData]
        public void ByEmail_requires_non_null_email()
        {
            Assert.Throws<ArgumentNullException>(() => SelectContact.ByEmail(null));
        }

        [Test, AutoData]
        public void ByUserToken_returns_proper_selector(string userToken)
        {
            Assert.That(SelectContact.ByUserToken(userToken), Is.InstanceOf<UserTokenContactSelector>());
        }

        [Test, AutoData]
        public void ByUserToken_requires_non_null_email()
        {
            Assert.Throws<ArgumentNullException>(() => SelectContact.ByUserToken(null));
        }

        [Test, AutoData]
        public void ById_returns_proper_selector(long contactId)
        {
            Assert.That(SelectContact.ById(contactId), Is.InstanceOf<IdContactSelector>());
        }
    }
}
