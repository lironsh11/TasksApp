import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  serverUrl = environment.serverUrl;
  arrTasks;
  currentTask: any;
  isUpdate = false;
  isAdd = false;
  errormsg;

  constructor(private Connection: HttpClient) {
    this.Connection.get(this.serverUrl+ "/Tasks").subscribe(t => this.arrTasks = t);
   }
  //function that chcek when you want to add a new task and isAdd go true
   getAdd() {
    this.isUpdate = false;
    this.isAdd = true;
  }
    //function that chcek when you want to update a task and isUpdate go true
   getUpdate(taskid: any) {
    this.isAdd = false;
    this.currentTask = taskid;
    this.isUpdate = true;
  }

      //function that delete a current task
  getDeleteTask(carid: any) {
    this.currentTask = carid
    this.isUpdate = false
    var choice = confirm("Are you sure you want to delete Task - " +  this.currentTask.taskTitle+ "?");
    if (choice == true) {
      this.Connection.delete(this.serverUrl + "/Tasks/" + this.currentTask.id, { "observe": "response" }).subscribe();
      alert("Task deleted!")
      setTimeout(function(){ window.location.reload();; }, 1000);
    } else {
      alert("You pressed Cancel! Nothing changed!")
    }

  }
    //function that check if the string is blank
  errorMsg(value: string): boolean {
    if (value == "") {
      this.errormsg = "required field"
      return true;
    }
    return false;
  }
     //function that add a new task
  addTask(title: string, description: string, date: string): void {
    if (this.errorMsg(title)) {

      return;
    }
    if (date == "") {
      date = null
    }
    if (description == "") {
      description = null
    }
    this.Connection.post(this.serverUrl + "/Tasks/AddTask", { "taskTitle": title,
                                                                       "taskDescription": description,
                                                                       "toDoDate": date,
                                                                      })
      .subscribe();
    alert("Changes has done!")
    setTimeout(function(){ window.location.reload();; }, 1000);
  }

       //function that update a current task
  UpdateTask(title: string,
    Description: string,
    date: string): void {
      if (this.errorMsg(title)) {

        return;
      }  
    if (date == "") {
      date = null
    }
    if (Description == "") {
      Description = null
    }

    this.Connection.put(this.serverUrl + "/Tasks/UpdateTask", {
      "id": this.currentTask.id,
      "taskTitle": title,
      "taskDescription": Description,
      "toDoDate": date,

    }).subscribe();
    alert("Changes has done");
    setTimeout(function(){ window.location.reload();; }, 1000);
  }
  ngOnInit(): void {
  }

}
