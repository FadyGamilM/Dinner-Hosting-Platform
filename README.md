# Dinner-Hosting-Platform
Take Your Home And Turn It Into A Restaurant.

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
      > {
      >>     "firstname" : "fady",
      >>      "lastname" : "gamil",
      >>       "email" : "fady@gmail.com",
      >>       "password" : "passw@rd" 
      > }
   - Response
      > {
      >>      "id" : "dfxav456-fasfasfcx-fasfasfas",****
      >>     "firstname" : "fady",
      >>      "lastname" : "gamil",
      >>       "email" : "fady@gmail.com",
      >>       "token" : "123Yx8fsx#3fsg"
      > }

 - **Login**
   - Request
      URL : 
      > `POST {{host}}/auth/login`

      Body : 
      > {
      >>       "email" : "fady@gmail.com",
      >>       "password" : "passw@rd" 
      > }
   - Response
      > {
      >>      "id" : "dfxav456-fasfasfcx-fasfasfas",
      >>     "firstname" : "fady",
      >>      "lastname" : "gamil",
      >>       "email" : "fady@gmail.com",
      >>       "token" : "123Yx8fsx#3fsg" 
      > }