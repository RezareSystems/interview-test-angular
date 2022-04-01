import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentService } from '../Service/student.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public students: Student[];
  response: boolean;

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //   http.get<Student[]>(baseUrl + 'students').subscribe(result => {
  //     this.students = result;
  //   }, error => console.error(error));
  // }
  constructor(private _studentService: StudentService){}

  ngOnInit(): void{
    this._studentService.getStudentList().subscribe(result =>{
      this.students = result;
    }, error => console.error(error));
  }

  deleteStudent(studentData: Student): void{
    this._studentService.deleteStudent(studentData).subscribe(result =>{
      this.response = result;
      
      if(this.response){
        alert('Deleted Successfully!');
        window.location.reload();
      }
    });
  }
}