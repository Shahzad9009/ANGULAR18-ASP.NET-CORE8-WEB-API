import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Employee } from '../Models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7010/api/Employee'
  constructor() { }

  http = inject(HttpClient)

  getAllEmployees() {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  addEmployee(data: any) {
    return this.http.post(this.apiUrl, data);
  }
  updateEmployee(employee: Employee) {
    return this.http.put(`${this.apiUrl}/${employee.id}`, employee)
  }
  deleteEmployee(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }


}
