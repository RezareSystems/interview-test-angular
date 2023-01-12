import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../home/home.component';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
})
export class AddStudentComponent {
    studentFormData: Object = {};
    httpClient: HttpClient;
    baseUrl: string;
  
    constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.httpClient = httpClient;
      this.baseUrl = baseUrl;
    }
  
    public handleSubmit(studentFormData) {
        console.log(studentFormData);
        this.httpClient
            .post<Student>(this.baseUrl + 'students/add', studentFormData)
            .subscribe(
                result => console.error(result),
                error => console.error(error)
            );
    }
}
