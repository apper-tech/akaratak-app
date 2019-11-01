import { Component, OnInit, ViewChild } from '@angular/core';
import { Property } from 'src/app/app.models';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { PropertyService } from 'src/app/shared/services/property.service';
import { PropertyDto } from 'src/app/shared/services/service.base';

@Component({
  selector: 'app-my-properties',
  templateUrl: './my-properties.component.html',
  styleUrls: ['./my-properties.component.scss']
})
export class MyPropertiesComponent implements OnInit {
  displayedColumns: string[] = ['id', 'image', 'title', 'published', 'views', 'actions'];
  dataSource: MatTableDataSource<PropertyDto>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(public propertyService: PropertyService) { }

  ngOnInit() {
    this.propertyService.getPropertiesForUser().then(res => {
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }).catch(error => {
      this.dataSource = new MatTableDataSource([]);
    });

  }

  public remove(property: PropertyDto) {
    const index: number = this.dataSource.data.indexOf(property);
    if (index !== -1) {
      this.propertyService.deleteProperty(property.id).then(result => {
        this.dataSource.data.splice(index, 1);
        this.dataSource = new MatTableDataSource<PropertyDto>(this.dataSource.data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }
  }

  public applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}