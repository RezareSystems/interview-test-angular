import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StudentService } from '../Service/student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-student-component',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  public student: Student;
  response: boolean;
  studentForm: FormGroup;

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, student: Student) {
  //   http.post<boolean>(baseUrl + 'students/add', {student}).subscribe(result => {
  //     this.successMessage = result;
  //   }, error => console.error(error));
  // }
  constructor(private _studentService: StudentService,
              private router: Router){}
  
  //properties declration
  fname: string;
  lname: string;
  email: string;
  major: string;
  gradeavg: string;

  ngOnInit(): void{
    this.resetFormFields();
  }

  //save student record
  save(): void {

    const studentData = {
      firstName: this.fname,
      lastName: this.lname,
      email: this.email,
      major: this.major,
      averageGrade: this.gradeavg
    } as Student;

    if(!this.checkFields()){
      this._studentService.addStudentToList(studentData).subscribe(result =>{
        this.response = result;
        
        if(this.response){
          alert('Saved Successfully!');
          this.resetFormFields();
          this.router.navigate(['/'])
        }
      });
    }
    else{
      alert('Fillout all values to the fields');
    }
  }

  resetFormFields(): void{
    this.fname = '';
    this.lname = '';
    this.email = '';
    this.major = '';
    this.gradeavg = '';
  }

  checkFields(): boolean{
    if(this.fname == '' || this.lname == '' ||
      this.email == '' || this.major == '' || 
      this.gradeavg == ''){
        return true;
      }
  }
}