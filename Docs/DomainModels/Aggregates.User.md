# Domain Models
## User

```csharp
class User
{
    User Create();
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "guestId": "00000000-0000-0000-0000-000000000000",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@company.com",
  "password": "*******"
}
```

> Note: Password should be hashed or cryptographed
> ToDo: redo in terms of HostId and GuestId