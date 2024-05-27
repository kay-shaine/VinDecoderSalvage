VIN Decoder and Salvage Check
This project is a web application that allows users to register, verify their phone number via OTP, log in, and then decode VIN numbers and check salvage data for vehicles. The application uses .NET Core 8 for the backend and Vue.js with TailwindCSS for the frontend.

Features
User registration with phone number verification via OTP
User login
VIN decoding and salvage data retrieval
Well-presented data showcasing VIN and salvage information
Error handling and unit tests for backend features
Technologies Used
Backend
.NET Core 7
Entity Framework Core
Mocked APIs for OTP verification and VIN decoding
CORS enabled
Frontend
Vue.js
TailwindCSS
Axios for API calls
Setup Instructions
Prerequisites
.NET Core 8 SDK
Node.js and npm
Vue CLI
SQL Server or any other configured database

Backend Setup
Clone the repository:

bash
Copy code
git clone https://github.com/kay-shaine/VinDecoderSalvage.git
cd VinDecoderSalvage/VinDecoderSalvageApi
Update the appsettings.json file with your database connection string.

Apply the database migrations:

bash
Copy code
dotnet ef database update
Run the backend:

bash
Copy code
dotnet run
Frontend Setup
Navigate to the frontend directory:

bash
Copy code
cd VinDecoderSalvage/VindecoderClient/vin-decoder-app
Install dependencies:

bash
Copy code
npm install
Run the frontend:

bash
Copy code
npm run serve
API Endpoints
User Registration: http://localhost:5010/api/User/register
OTP Verification: http://localhost:5010/api/User/verifyOtp
Send OTP: http://localhost:5010/api/User/sendOtp
VIN Decoding: http://localhost:5010/api/Vin/decode/{vin}
Mocking API Services
For the purpose of development and testing, the following APIs are mocked:

Send OTP: Generates a random OTP and saves it to the database.
Verify OTP: Verifies the provided OTP against the stored value.
VIN Decoding: Returns a mocked VIN decoding and salvage data response.
Unit Testing
Unit tests are written for the backend using xUnit and Moq. To run the tests:

Navigate to the test project directory:

bash
Copy code
cd your-repository/VinDecoderApi.Tests
Run the tests:

bash
Copy code
dotnet test
Usage
Register a new user by providing a name and phone number.
Verify the phone number by entering the OTP sent.
Log in using the verified phone number.
Enter a VIN number to decode and retrieve salvage data.
Screenshots
Add screenshots of the application here.

Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any questions or issues, please contact kehinde.enigbokan@gmail.com.
