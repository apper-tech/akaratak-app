import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-properties-search-results-filters',
  templateUrl: './properties-search-results-filters.component.html',
  styleUrls: ['./properties-search-results-filters.component.scss']
})
export class PropertiesSearchResultsFiltersComponent implements OnInit {
  @Input() searchFields: any;
  @Output() onRemoveSearchField: EventEmitter<any> = new EventEmitter<any>();
  constructor() { }

  ngOnInit() { }
  ngOnChanges(changes: SimpleChanges): void {
    //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
    //Add '${implements OnChanges}' to the class.
    console.log(this.searchFields);

  }
  public remove(field) {
    if (field == 'country')
      this.onRemoveSearchField.emit('city');
    this.onRemoveSearchField.emit(field);
  }

}