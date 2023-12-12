import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'technician-component',
  templateUrl: './technicians.component.html',
  styleUrls: ['./technicians.component.css']
})
export class TechniciansComponent implements OnInit {
  constructor(private dataService: DataService) { }

  displayedColumns: string[] = ['id', 'name', 'specialization']; // Replace these with your actual column names
  dataSource: any[] = []; // Replace this with your data array

  ngOnInit(): void {
    // You can initialize or fetch data for dataSource here
    this.dataSource = [
      { id: 1, name: 'Technician 1', specialization: 'Specialization 1' },
      { id: 2, name: 'Technician 2', specialization: 'Specialization 2' },
      // Add more data objects as needed
    ];
  }

  applyFilter($event: KeyboardEvent) {
    // Implement your filter logic here
  }
}
