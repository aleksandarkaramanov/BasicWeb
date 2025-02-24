
# WebApp API Documentation

This API provides endpoints for managing **Companies**, **Countries**, and **Contacts** in the system. You can perform CRUD operations for each of these entities.

## Base URL
```
http://localhost:7271/api/
```

## Endpoints

### Company API

#### Add a Company
- **Endpoint**: `POST /api/Company`
- **Description**: Adds a new company.If the new company is saved, the ID under which it was saved is returned as a response.
- **Request Body**:
```json
{
  "companyName": "string"
}
```
- **Response**:
```json
{
  "companyId": 1
}
```

#### Get All Companies
- **Endpoint**: `GET /api/Company`
- **Description**: Retrieves a list of all companies.
- **Response**:
```json
[
  {
    "companyId": 1,
    "companyName": "Company 1"
  },
  {
    "companyId": 2,
    "companyName": "Company 2"
  }
]
```

#### Get Company by ID
- **Endpoint**: `GET /api/Company/{companyId}`
- **Description**: Retrieves a single company by its ID.The ID will be sent in the URL path.
- **Response**:
```json
{
  "companyId": 1,
  "companyName": "Company 1"
}
```

#### Update Company
- **Endpoint**: `PUT /api/Company/{companyId}`
- **Description**: Updates a companyís details.The ID of the company we want to update will be sent in the URL path.
- **Request Body**:
```json
{
  "companyName": "string"
}
```
- **Response**:
```json
{
  "affectedRows": 1
}
```

#### Delete Company
- **Endpoint**: `DELETE /api/Company/{companyId}`
- **Description**: Deletes a company by its ID.The ID will be sent in the URL path.
- **Response**: `200 OK`

---

### Country API

#### Add a Country
- **Endpoint**: `POST /api/Country`
- **Description**: Adds a new country.In the Request body, we will delete the Id section because it is generated automatically.If the new contact is saved, the ID under which it was saved is returned as a response.
- **Request Body**:
```json
{
  "countryId":"0"
  "countryName": "string"
}
```
- **Response**:
```json
{
  "countryId": 1
}
```

#### Get All Countries
- **Endpoint**: `GET /api/Country`
- **Description**: Retrieves a list of all countries.
- **Response**:
```json
[
  {
    "countryId": 1,
    "countryName": "Country 1"
  },
  {
    "countryId": 2,
    "countryName": "Country 2"
  }
]
```

#### Get Country by ID
- **Endpoint**: `GET /api/Country/{countryId}`
- **Description**: Retrieves a single country by its ID.The ID will be sent in the URL path.
- **Response**:
```json
{
  "countryId": 1,
  "countryName": "Country 1"
}
```

#### Update Country
- **Endpoint**: `PUT /api/Country/{countryId}`
- **Description**: Updates a country's details.The ID of the country we want to update will be sent in the URL path.
- **Request Body**:
```json
{
  "countryId": 0,
  "countryName": "string"
}
```
- **Response**:
```json
{
  "affectedRows": 1
}
```

#### Delete Country
- **Endpoint**: `DELETE /api/Country/{countryId}`
- **Description**: Deletes a country by its ID.The ID will be sent in the URL path.
- **Response**: `200 OK`

---

### Contact API

#### Add a Contact
- **Endpoint**: `POST /api/Contact`
- **Description**: Adds a new contact.If the new contact is saved, the ID under which it was saved is returned as a response.In the Request body, we will delete the contactId section because it is generated automatically.We will delete the company and country section, we will only enter the companyId and countryId with which we want to associate the contact.
- **Request Body**:
```json
{
  "contactId": 0,
  "contactName": "string",
  "companyId": 0,
  "company": {
    "companyName": "string"
  },
  "countryId": 0,
  "country": {
    "countryId": 0,
    "countryName": "string"
  }
}
```
- **Response**:
```json
{
  "contactId": 1
}
```

#### Get All Contacts
- **Endpoint**: `GET /api/Contact`
- **Description**: Retrieves a list of all contacts.
- **Response**:
```json
[
  {
    "contactId": 1,
    "contactName": "Contact 1",
    "companyId": 1,
    "company": {
      "companyId": 1,
      "companyName": "IT Company"
    },
    "countryId": 1,
    "country": {
      "countryId": 1,
      "countryName": "Macedonia"
    }
  }
]
```

#### Get Contact by ID
- **Endpoint**: `GET /api/Contact/{contactId}`
- **Description**: Retrieves a single contact by its ID.
- **Response**:
```json
  {
    "contactId": 1,
    "contactName": "Contact 1",
    "companyId": 1,
    "company": {
      "companyId": 1,
      "companyName": "IT Company"
    },
    "countryId": 1,
    "country": {
      "countryId": 1,
      "countryName": "Macedonia"
    }
  }
```

#### Update Contact
- **Endpoint**: `PUT /api/Contact/{contactId}`
- **Description**: Updates a contact's details.The ID will be sent in the URL path.In the Request body, we will delete the contactId section because it is generated automatically.We will delete the company and country section, we will only enter the companyId and countryId with which we want to associate the contact.
- **Request Body**:
```json
{
  "contactId": 0,
  "contactName": "string",
  "companyId": 0,
  "company": {
    "companyName": "string"
  },
  "countryId": 0,
  "country": {
    "countryId": 0,
    "countryName": "string"
  }
}
```
- **Response**:
```json
{
  "affectedRows": 1
}
```

#### Delete Contact
- **Endpoint**: `DELETE /api/Contact/{contactId}`
- **Description**: Deletes a contact by its ID.The ID will be sent in the URL path.
- **Response**: `200 OK`

#### Get All Contacts with Details
- **Endpoint**: `GET /api/Contact/contactsWithDetails`
- **Description**: Retrieves all contacts along with their associated company and country names.
- **Response**:
```json
  [
    {
    "contactId": 1,
    "contactName": "Contact 1",
    "companyName": "IT Company",
    "countryName": "Macedonia"
    },
    {
    "contactId": 2,
    "contactName": "Contact 2",
    "companyName": "Kompanija",
    "countryName": "Macedonia"
    }
  ]
```
#### Filter Contacts by Country and Company
- **Endpoint**: `GET /api/contact/filter`
- **Description**: Filters contacts based on the provided `countryId` and/or `companyId`. If no parameters are provided, it returns all contacts. This endpoint is useful for narrowing down contacts by country or company association.
- **RequestURL**:`https://localhost:7271/api/Contact/filter?countryId=1&companyId=1`
- **Response**:
```json
[
  {
    "contactId": 1,
    "contactName": "Contact 1",
    "companyId": 1,
    "company": {
      "companyId": 1,
      "companyName": "IT Company"
    },
    "countryId": 1,
    "country": {
      "countryId": 1,
      "countryName": "Macedonia"
    }
  },
  {
    "contactId": 3,
    "contactName": " ÓÏÔ‡ÌËº‡",
    "companyId": 1,
    "company": {
      "companyId": 1,
      "companyName": "IT Company"
    },
    "countryId": 1,
    "country": {
      "countryId": 1,
      "countryName": "Macedonia"
    }
  }
]
```
---
# Authentication and Authorization

## 1. Authentication Setup
This API uses JWT-based authentication. To access protected endpoints, you must first register and log in to obtain a token.

### **Register a User**
- **Endpoint**: `POST /register`
- **Description**: Register as a user with email and password
- **Request Body**:
```json
{
  "email": "dani@gmail.com",
  "password": "Password@123"
}
```
- **Response**: `200 OK`

### **Register a User**
- **Endpoint**: `POST /login`
- **Description**: Log in with the email and password you previously registered with.
- **Response**:
```json
{
  "tokenType": "Bearer",
  "accessToken": "CfDJ8DzsYOj5o9xBhnqsfsBlL9hB3nwEEx0kdHLL_sC_ZHVIqJ6C_dhEG7jnBcGcJe8R_sTe3zb3OYi8Di7_f1ZNKJmJOyi3fuQyp2JOCDoKhD3PguZpQcJHI0N7kATvXw1xccOO2816HsQIOUdZZ51qx-i5dUhAPFymPTqZoGRCmTVBenhxUar8GpC3tkzo4XrXItIq5xT9wHjgsKXjyqf5pBRbm121GHomCzRhjZVd5z1hzFCtGprad5UnFS_WMTpXd04xrH7w370vLezffxXMOYujNyyLk3uT9MerbPiQMOyuX1e8TCWUiMLI7yUxSz8S9NyXzE_hPO4xlYGed-TmqbsnbfBFgYIGFf_D5kFCWfeJhrwcKxpf1hZwSZP5Zwb0rqvEqdCSe6JwAn7AX6vpKI-Oqkv1AX81oqnSIZSOJV9fMrNp-E_usETLCjQXmjtnD58OynRUh4--Ki4MJmSrk3AURs0bmmtPkJx2QBat7qF8KsxGvlgU98qXY8HiZ8UDUtxIARH5jWCzZIUv7IvjZ8826YbMVnsXOhhYwtz_WewhY9_lPa4HY6f7G3BYHrpMcugS5LoIEOZBKkR8ZgWCOQ3wMCc5nNTmIKlQRQmAQHjkHVjz8P6gGN4oRzhvKWSvhPh3qNxKVWYtOnLbFinlMvDzDVeR2DsBw38bIVbgZK0PYGiPxdZ8UGXfu7UcqfcImg",
  "expiresIn": 3600,
  "refreshToken": "CfDJ8DzsYOj5o9xBhnqsfsBlL9jK8xjqzUT6BCxVQvrkBUA4AtfCLooYgjxgBcOovsnuKEUTAIgEOO8au7xo-o-ICuUbzpD4ex_PYVbNHYhhL9z9PHkiSu1plJpwhffHal4Ss3xuGDuJgsr8wPi5_pqU-Mu4EqYy4w31YKdTQagxbqf_bAmqE-begtWkn9sG5v_Ho7AhhkFAjZ6VCTLK8n-ql09IoVCDJykHVGCspuP6ILgWSgCAlP6IXzgWvdAk-VhHCqyQ1GBYrcvQC8OAaKg3U0j5FHQQ-ztXVCZOOdlHDGiGS0ClIv7EoHi2LdKj1ePWMe2KTY8IAkjqhW7fzqr7MsAxw4MS-tST2SSDJY0ayo76RoM4YyjMbyGXdn08qSpUey-ZE-gOGcB3w_abV6LV648j6CgBU7Hc8BC5QTDM8KvBro_NHY8cXp5aMulvg7xO25LFP87sna6cvDTvNFSxGd2bHrSavI4Jmr1ebThTMXDXaJw687p5XIE-hzOtJ1U8Pixp-v6zEygaxxmUHoKCmpM5JmbMPTBfmo_yZqLdGfX6WalOiiZ8bvybxyEnslPKUWb4tnbwhXub8NdbnvhvNpOJSHsJa-f7GPfqUxePDFVb_jBVI3-ptyh5yH9zDy2hSdoF0RfVrIr2ELHTw8rGEgO4hIPe0sliuCaBa2QxpB1uLpplznDOIOFMI_XXjyxHlw"
}
```
### **Authorize**
After logging in, you need to authorize to use /api/Contact/Filter.To authorize, you need the token you receive when you log in.



## Status Codes

- `200 OK`: The request was successful.
- `201 Created`: The resource was created successfully.
- `400 Bad Request`: There was an issue with the request data.
- `404 Not Found`: The resource could not be found.
- `500 Internal Server Error`: There was an unexpected error on the server.
