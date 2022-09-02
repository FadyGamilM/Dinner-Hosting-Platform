# Dinner-Hosting-Platform
Take Your Home And Turn It Into A Restaurant.

# Dinner Hosting Platform - Domain/Core Layer.
## Domain Models
- ### USER
``` json
{
  "Id" : "1a8bbede-3089-45ad-920e-64b12b7c833b",
  "firstName": "Fady",
  "lastName": "Gamil",
  "email" : "fady@gmail.com",
  "password": "p@ssw0rd" // will be updated
}
```

# Dinner Hosting Platform - API Layer.


- **`API Project`**
  - **`Auth`**
    - **`Register`**
      - **`Register Request`**
      - **`Register Response`**
    - **`Login`**
      - **`Login Request`**
      - **`Login Response`**

> ### **End Points**
 - **Register**
   - Request
      URL : 
      > `POST {{host}}/auth/register`

      Body : 
    ``` json
      {
        "firstname" : "fady",
        "lastname" : "gamil",
        "email" : "fady@gmail.com",
        "password" : "passw@rd" 
    }
    ```
  - Response
  
  ```json
    {
      "id" : "dfxav456-fasfasfcx-fasfasfas",
      "firstname" : "fady",
      "lastname" : "gamil",
      "email" : "fady@gmail.com",
      "token" : "123Yx8fsx#3fsg"
    }
  ```

 - **Login**
   - Request
      URL : 
      > `POST {{host}}/auth/login`

      Body :
      ```json 
      {
        "email" : "fady@gmail.com",
        "password" : "passw@rd" 
      }
      ```
   - Response
  ```json
    {
      "id" : "dfxav456-fasfasfcx-fasfasfas",
      "firstname" : "fady",
      "lastname" : "gamil",
      "email" : "fady@gmail.com",
      "token" : "123Yx8fsx#3fsg"
    }
  ```
