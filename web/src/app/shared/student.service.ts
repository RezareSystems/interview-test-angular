import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Student } from './student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getStudents() {
    return this.http.get(this.baseUrl + 'Students');
  }

  addStudent(data:Student) {
    return this.http.post(this.baseUrl + 'Students/add', data)
  }

  detailsStudent(data:Student) {
    return this.http.post(this.baseUrl + 'Students/details', data)
  }

  editStudent(data:Student) {
    return this.http.post(this.baseUrl + 'Students/edit', data)
  }

  deleteStudent(data:Student) {

    return this.http.post(this.baseUrl + 'Students/delete', data);
  }
}
