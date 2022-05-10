import { Component, Inject } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public students: Student[];
  public student: Student;

  public isNew:boolean;

  constructor(public apiService: StudentService) { }

  ngOnInit() {
    this.student = new Student();
    this.loadStudents();
  }

  displayStyle = "none";

  openPopup(isAdd:boolean) {
    if(isAdd){
      this.isNew = true;
      this.student = new Student();
    }
    this.displayStyle = "block";
  }
  closePopup() {
    this.displayStyle = "none";
  }

  loadStudents() {
    this.apiService.getStudents().subscribe(res => {
      this.students = res as Student[]
    }, error => console.log(error));
  }

  onClickAdd(isNew:boolean) {
    if (!this.student.firstName) {
      alert('First name is required!');
      return;
    }
    if (!this.student.lastName) {
      alert('Last name is required!');
      return;
    }
    if (!this.student.email) {
      alert('Email is required!');
      return;
    }
    if (!this.student.major) {
      alert('Major is required!');
      return;
    }
    if (isNew) {
      this.apiService.addStudent(this.student).subscribe(res => {
        this.closePopup();
        console.log(res);
        this.loadStudents();
      }, error => console.log(error));
    } else {
      this.apiService.editStudent(this.student).subscribe(res => {
        this.student = new Student();
        this.closePopup();
        this.loadStudents();
      }, error => console.log(error));
    }
  }

  onClickEdit(data:Student) {
    this.apiService.detailsStudent(data).subscribe(res => {
      this.student = res as Student;
      this.isNew = false;
      this.openPopup(false);
    }, error => console.log(error));
  }

  onClickDelete(data: Student) {
    this.apiService.deleteStudent(data).subscribe(res => {
      console.log(res);
      this.loadStudents();
    }, error => console.log(error));
  }
}
