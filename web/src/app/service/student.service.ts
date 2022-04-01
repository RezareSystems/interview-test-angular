// Dependencies
import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class StudentService {
    constructor(private httpClient: HttpClient) {}

    //get all student list from API.
    getStudentList(): Observable<Student[]>{
        return this.httpClient.get<Student[]>('https://localhost:44335/students');
    }

    //add student to the list.
    addStudentToList(student: Student): Observable<boolean>{
        return this.httpClient.post<boolean>('https://localhost:44335/students/add', {student});
    }

    deleteStudent(student: Student): Observable<boolean>{
        return this.httpClient.post<boolean>('https://localhost:44335/students/delete', {student});
    }
}
