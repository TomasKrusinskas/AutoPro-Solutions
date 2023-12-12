import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CenterService } from '../services/center.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from '../core/core.service';

@Component({
  selector: 'app-centers',
  templateUrl: './centers.component.html',
  styleUrls: ['./centers.component.css'],
})
export class CentersComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'description'
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private dialog: MatDialog,
    private centersService: CenterService,
    private coreService: CoreService
  ) {}

  ngOnInit(): void {
    this.getCenterList(); // Fetch data on component initialization
  }

  getCenterList(): void {
    this.centersService.getCenters().subscribe(
      (data: any) => {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteCenter(id: number) {
    this.centersService.deleteCenter(id).subscribe({
      next: () => {
        this.coreService.openSnackBar('Center deleted!', 'done');
        this.getCenterList();
      },
      error: console.log,
    });
  }
}
