# Freshdesk.NET - A simple .NET Freshdesk REST Client
The primary design goal of the Freshdesk.NET client is to abstract Freshdesk's JSON API and present the developer with a simplified and strongly typed implementation. Much of the underlying mechanics have therefore purposefully been abstracted behind private modifiers.

## Release Notes
The current release notes can be read in [CHANGELOG.md](https://github.com/jscarle/Freshdesk.NET/blob/master/CHANGELOG.md).

## Dependencies
Both [RestSharp](https://github.com/restsharp/RestSharp) and [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) are required dependencies.

## Quick Start

### Creating an instance of the client
```csharp
FreshdeskClient freshdesk = new FreshdeskClient("yourcompany.freshdesk.com", "yourapikey", "X");
```

### Retrieving all contacts
```csharp
(Response response, List<Contact> contacts) = freshdesk.GetContacts();
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contacts.Count);
```

### Retrieving a single contact
```csharp
(Response response, Contact contact) = freshdesk.GetContact(28000000001);
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contact.Name);
```

### Creating a contact
```csharp
NewContact newContact = new NewContact();
newContact.Name = "John Doe";
newContact.Email = "john.doe@unidentified.com";
(Response response, Contact contact) = freshdesk.CreateContact(newContact);
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contact.ID);
```
