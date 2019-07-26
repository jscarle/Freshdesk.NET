# Freshdesk.NET - A simple .NET Freshdesk REST Client
The primary design goal of the Freshdesk.NET client is to abstract Freshdesk's JSON API and present the developer with a simplified and strongly typed implementation. Much of the underlying mechanics have therefore purposefully been abstracted behind private modifiers.

## Release Notes
The current release notes can be read in [CHANGELOG.md](https://github.com/jscarle/Freshdesk.NET/blob/master/CHANGELOG.md).

## Dependencies
Both [RestSharp](https://github.com/restsharp/RestSharp) and [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) are required dependencies.

## Quick Start
Make sure to consult the [Wiki](https://github.com/jscarle/Freshdesk.NET/wiki) for the full documentation.

### Creating an instance of the client
```csharp
string freshdeskDomain = "yourcompany.freshdesk.com";
string apiKey = "yourapikey";
FreshdeskClient freshdesk = new FreshdeskClient(freshdeskDomain, apiKey, "X");
```

### Retrieving all contacts
```csharp
(Response response, List<Contact> contacts) = freshdesk.GetContacts();
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contacts.Count);
```

### Retrieving a single contact
```csharp
(Response response, Contact contact) = freshdesk.GetContact(28000000000);
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contact.Name);
```

### Creating a contact
```csharp
NewContact newContact = new NewContact();
newContact.Name = "Iosef Tarasov";
newContact.Email = "iosef tarasov@mafia.ru";
(Response response, Contact contact) = freshdesk.CreateContact(newContact);
if (response.StatusCode == HttpStatusCode.Created)
    Console.WriteLine(contact.ID);
```

### Updating a contact
```csharp
Contact contact = new Contact();
contact.ID = 28000000002;
contact.Name = "John Wick";
contact.Email = "john.wick@hightable.org";
(Response response, Contact contact) = freshdesk.UpdateContact(contact);
if (response.StatusCode == HttpStatusCode.OK)
    Console.WriteLine(contact.Name);
```

### Deleting a contact
```csharp
Response response = freshdesk.DeleteContact(28000000001);
if (response.StatusCode == HttpStatusCode.NoContent)
    Console.WriteLine("Iosef didn't make it.");
```
