# InstaPay Mini

**InstaPay Mini** is a simple C# console application that simulates a mini money transfer app. It allows users to sign up, log in, send and receive money, deposit, withdraw, and view transaction history. All critical actions require PIN confirmation for security.

This project demonstrates the application of **Object-Oriented Programming (OOP) principles**:

* **Encapsulation:** User and Transaction data are encapsulated with properties and methods, controlling access to sensitive information like PIN and balance.
* **Abstraction:** Users interact with a simple menu interface without needing to know internal logic or data handling.
* **Inheritance:** Can be extended to create different user types (e.g., admin, premium users).
* **Polymorphism:** Future methods can handle multiple transaction types using the same interface.

---

## Features

* User Sign Up and Login
* View account balance (with PIN confirmation)
* Send money to other users (with validation and PIN confirmation)
* Deposit and withdraw money securely
* Transaction history summary
* Update user profile (full name and phone)

---

## Getting Started

### Requirements

* .NET 6.0 or later
* Any C# compatible IDE (Visual Studio, VS Code)

### How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/instapay-mini.git
   ```
2. Open the solution in Visual Studio or VS Code.
3. Build the project.
4. Run the console application.
5. Follow the on-screen menu to interact with the system.

---

## Example Usage

* Sign up a new user
* Login with username and password
* Deposit 1000 EGP using PIN
* Send 500 EGP to another user
* View transaction summary

---

## Future Improvements

* Save user and transaction data to a file or database (persistence).
* Add more transaction types (e.g., bill payments, international transfers).
* Implement more OOP concepts like interfaces and abstract classes.
* Add unit tests for all core functionalities.

---

## License

MIT License – free to use and modify.
