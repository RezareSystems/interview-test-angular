import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'app-student',
    templateUrl: './student.component.html'
})

export class StudentComponent implements OnInit {

    student: Student = {
        firstName: '',
        lastName: '',
        email: '',
        major: '',
        averageGrade: null,
        id: 0
    };

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit(): void { }

    onSubmit() {
        this.http.post(this.baseUrl + 'students', this.student,
            {
                headers: new HttpHeaders({ 'Access-Control-Allow-Origin': '*' })
            }).subscribe(
                (response) => console.log(response),
                (error) => console.log(error)
            );
    }
}

interface Student {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    major: string;
    averageGrade: number
}
