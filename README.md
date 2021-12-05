# Appointment Booking System

- Neh Thakkar - 200458205 - COMP208421F11247
- Link to Live Website : http://nehthakkar-001-site1.dtempurl.com/
- Link to Source Code : https://github.com/NehThakkar/Appointment_System.git
- The purpose of this Web App is to basically let the businesses handle their timings by assigning appointments to their visitors! Currently, it just let's us create both the appointment and admins but its actual functionality is just to let some particular admins edit the appointments booked by customers. 

- It currently has three different role identities : 
- - Admin Credentials (email : rich@gc.ca , password : Test123$) - Registered Admins can access all the information including admins and customers with access to edit/delete them all
- - Pharmacist Credentials (email : pharmacist@gc.ca , password : Test123$) - Registered Pharmacists cannot edit or delete the dose admins (can see them) but edit/delete the appointments
- - Customers Credentials (email : customer@gc.ca , password : Test123$) - Registered Customers can just book appointments and see other appointments
- - Unknown Users - who are not registered, can only book appointments without having access to any of the information

### - It does not support Google registration because this live website does not come with SSL whereas the Google URI field cannot take URIs with just 'http' (has to be 'https')

- The test methods have been added for ApoointmentsController - DELETE (GET)
- 1) To check if it loads "404" when input is null
- 2) To check if it loads "404" when input not null but invalid appointmentId
- 3) To check if it loads Delete View when input is Valid
- 4) To check if it loads Delete View for passed exact apoointment when input Valid
- 5) To check if it doesn't loads Delete View for any other apoointment when input is valid

- I am still keeping an open approach to look around for idea improvements and enhance the user experience by adding the APIs and I'll also try to work on collaborating with local device calenders.
