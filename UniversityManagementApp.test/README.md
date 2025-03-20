# University Management App - Testing Documentation

## Functional Test Results

### Student Functionality Tests

#### Enrollment Test
- **Description**: Verify that a student can enroll in a subject and that it appears in their enrolled subjects list.
- **Steps**:
  1. Log in as a student
  2. Navigate to "Available Subjects"
  3. Select a subject and click "Enroll"
  4. Navigate to "My Subjects"
- **Expected Result**: The subject appears in the student's enrolled subjects list
- **Actual Result**: The subject successfully appears in the "My Subjects" list
- **Status**: PASS

#### Drop Subject Test
- **Description**: Verify that a student can drop a subject, and it reappears in the available subjects list.
- **Steps**:
  1. Log in as a student
  2. Navigate to "My Subjects"
  3. Select a subject and click "Drop"
  4. Check "Available Subjects"
- **Expected Result**: The subject is removed from "My Subjects" and appears in "Available Subjects"
- **Actual Result**: The subject was successfully removed from "My Subjects" and reappeared in "Available Subjects"
- **Status**: PASS

### Teacher Functionality Tests

#### Create Subject Test
- **Description**: Verify that a teacher can create a subject and it appears in both "My Subjects" and "Available Subjects".
- **Steps**:
  1. Log in as a teacher
  2. Navigate to "Create Subject"
  3. Fill in subject details and submit
  4. Check "My Subjects" and "Available Subjects"
- **Expected Result**: The new subject appears in both lists
- **Actual Result**: The subject appears in both "My Subjects" and "Available Subjects" lists
- **Status**: PASS

#### Delete Subject Test
- **Description**: Verify that deleting a subject removes it from both "My Subjects" and "Available Subjects".
- **Steps**:
  1. Log in as a teacher
  2. Navigate to "My Subjects"
  3. Select a subject and click "Delete"
  4. Check "My Subjects" and "Available Subjects"
- **Expected Result**: The subject is removed from both lists
- **Actual Result**: The subject was successfully removed from both "My Subjects" and "Available Subjects" lists
- **Status**: PASS

### System-Level Tests

#### Login Test
- **Description**: Ensure that login validation works for both Student and Teacher roles.
- **Steps**:
  1. Launch the application
  2. Enter credentials for a student account and login
  3. Logout
  4. Enter credentials for a teacher account and login
  5. Try incorrect credentials
- **Expected Result**: Successful login for correct student and teacher credentials, access denied for incorrect credentials
- **Actual Result**: Successfully logged in as student and teacher with correct credentials. Access was denied with incorrect credentials.
- **Status**: PASS

#### Data Persistence Test
- **Description**: Verify that all changes are saved to the JSON file and persist after reopening the application.
- **Steps**:
  1. Make changes (enroll in subjects, create subjects, etc.)
  2. Close the application
  3. Reopen the application and check if changes persisted
- **Expected Result**: All changes are saved and visible after reopening
- **Actual Result**: All changes were correctly saved to JSON files and loaded upon reopening
- **Status**: PASS
