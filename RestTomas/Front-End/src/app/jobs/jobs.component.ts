import { Component } from '@angular/core';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent {
  jobsData = [
    { id: 1, title: 'Job Title 1', description: 'Description for Job 1' },
    { id: 2, title: 'Job Title 2', description: 'Description for Job 2' },
  ];
}
