import API from "../ApiConfig";
import Cookies from "js-cookie";

export async function GetEmployees() {
  let response = await API.get("/Employee", {
    headers: {
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).catch((error) => {
    return [];
  });

  if (response.status === 200) {
    return response.data;
  }
  return [];
}

export async function PostEmployee(Employee) {
  await API.post("/Employee", {
    "username": Employee.username,
    "emailAddress": Employee.emailAddress,
    "password": Employee.password,
    "firstName": Employee.firstName,
    "lastName": Employee.lastName,
    "dateOfBirth": Employee.dateOfBirth,
    "seniority": parseInt(Employee.seniority),
    "role": parseInt(Employee.role)
  }, {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).then(({data}) => console.log(data));
}

export async function EditEmployee(id, Employee, dateOfBirth) {
  await API.post(`/Employee/${id}`, {
    "username": Employee.username,
    "emailAddress": Employee.emailAddress,
    "password": Employee.password,
    "firstName": Employee.firstName,
    "lastName": Employee.lastName,
    "dateOfBirth": dateOfBirth,
    "seniority": parseInt(Employee.seniority),
    "role": parseInt(Employee.role)
  }, {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${Cookies.get("user_session")}`,
    },
  }).then(({data}) => console.log(data));
}