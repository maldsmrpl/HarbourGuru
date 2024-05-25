# HarbourGuru

## Project Overview

### Introduction
HarbourGuru is a dynamic ASP.NET MVC web application crafted to meet the unique needs of seafarers by providing a platform for sharing and accessing essential information about port services. The maritime industry thrives on the seamless flow of information, and HarbourGuru bridges the gap by connecting seafarers with vital contacts and services in various ports around the world. Whether it's finding a reliable taxi driver, locating a seamen's mission, or contacting shipchandlers, HarbourGuru ensures that users have the information they need at their fingertips.

### Purpose
The primary objective of HarbourGuru is to create a centralized, user-driven database of port-related contacts and services. This database aims to enhance the efficiency, safety, and convenience of port visits for seafarers. By leveraging the collective knowledge and experiences of its users, HarbourGuru facilitates informed decision-making, reduces the risk of encountering unreliable services, and ultimately improves the overall experience of seafaring professionals.

### Key Features
1. **User Authentication and Management**:
   - Built using ASP.NET Core Identity, HarbourGuru provides secure user authentication and role-based authorization. Users can register, log in, and manage their profiles with ease, ensuring a personalized and secure experience.

2. **Comprehensive Service Listings**:
   - HarbourGuru allows users to add and browse detailed listings of various port services. Each listing, or "HarbourCard," includes crucial information such as the service name, description, contact details, and category.

3. **Categorization and Organization**:
   - Services are categorized into intuitive categories such as transportation, supplies, and welfare. This categorization aids in easy navigation and quick access to relevant information.

4. **User Reviews and Ratings**:
   - To maintain the quality and reliability of the information, users can leave reviews and ratings for the services they use. This feature enables other users to make informed choices based on peer feedback.

5. **Global Coverage**:
   - HarbourGuru supports an extensive database that covers ports from around the globe. Users can search for services in specific countries and harbours, making it a versatile tool for international seafarers.

### Data Model Architecture
HarbourGuru's data models are designed to capture a wide range of information related to ports and their services. Key models include:

- **AppUser**:
  - Extends `IdentityUser` to include timestamps for user activities and a collection of reviews written by the user.

- **Country**:
  - Represents countries with attributes such as a unique identifier, country code, and country name, along with a collection of associated harbours.

- **Harbour**:
  - Captures details about individual harbours, including harbour code, name, and a reference to the country it belongs to.

- **HarbourCard**:
  - Stores information about specific services at a harbour, including service name, description, contact details, and associated reviews.

- **HarbourCardCategory**:
  - Defines various categories for harbour services, ensuring organized and easy-to-navigate service listings.

- **HarbourCardPhone**:
  - Manages contact phone numbers for services, including phone number details and descriptions.

- **HarbourCardReview**:
  - Allows users to provide ratings and comments on services, which helps maintain the reliability and usefulness of the service listings.

### User Experience
HarbourGuru is designed with a user-friendly interface that prioritizes ease of use and accessibility. Key user experience elements include:

- **Intuitive Navigation**:
  - Users can easily browse through categories, search for specific services, and filter results based on various criteria such as location and service type.

- **Detailed Service Information**:
  - Each HarbourCard provides comprehensive details, ensuring users have all the necessary information to make informed decisions.

- **Interactive Review System**:
  - The review and rating system is simple to use, encouraging users to share their experiences and help improve the community database.

- **Responsive Design**:
  - HarbourGuru is optimized for various devices, ensuring a seamless experience whether accessed from a desktop, tablet, or smartphone.

### Community and Collaboration
At its core, HarbourGuru thrives on the contributions of its users. The platform encourages seafarers to share their knowledge and experiences, creating a collaborative environment where valuable information is continuously updated and verified by the community. This collaborative approach not only enriches the database but also fosters a sense of camaraderie among seafarers worldwide.

### Conclusion
HarbourGuru is more than just a web application; it is a vital resource for the global seafaring community. By providing a centralized platform for sharing and accessing port service information, HarbourGuru enhances the efficiency, safety, and convenience of maritime operations. Its robust features, user-friendly design, and community-driven approach make it an indispensable tool for seafarers navigating the complexities of international ports.
