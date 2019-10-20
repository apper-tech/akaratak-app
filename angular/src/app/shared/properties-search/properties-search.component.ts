import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category } from '../../app.models'
import { AppService } from '../../app.service';
import { PropertyService } from '../services/property.service';
import { CategoryDto, CountryDto } from '../services/service.base';

@Component({
  selector: 'app-properties-search',
  templateUrl: './properties-search.component.html',
  styleUrls: ['./properties-search.component.scss']
})
export class PropertiesSearchComponent implements OnInit {
  @Input() variant: number = 1;
  @Input() vertical: boolean = false;
  @Input() searchOnBtnClick: boolean = false;
  @Input() removedSearchField: string;
  @Output() onSearchChange: EventEmitter<any> = new EventEmitter<any>();
  @Output() onSearchClick: EventEmitter<any> = new EventEmitter<any>();
  public showMore: boolean = false;
  public form: FormGroup;
  public propertyTypes: CategoryDto[];
  public propertyStatuses = [];
  public countries = [];
  public cities = [];
  public streets = [];
  public features = [];
  public filteredTypes;
  public filteredCities;
  public filteredCountries;
  constructor(public appService: AppService,
    public propertyService: PropertyService,
    public fb: FormBuilder) { }

  ngOnInit() {
    if (this.vertical) {
      this.showMore = true;
    };

    this.propertyService.getPropertyTypes().subscribe((data) => {
      this.propertyTypes = data;
      this.filteredTypes = data.slice();
    });
    this.propertyService.GetCountries().subscribe((data) => {
      this.countries = data;
      this.filteredCountries = data.slice();
    });
    this.propertyStatuses = this.appService.getPropertyStatuses();
    this.features = this.propertyService.getFeatures();
    this.form = this.fb.group({
      propertyType: null,
      propertyStatus: null,
      price: this.fb.group({
        from: null,
        to: null
      }),
      country: null,
      city: null,
      zipCode: null,
      street: null,
      bedrooms: this.fb.group({
        from: null,
        to: null
      }),
      bathrooms: this.fb.group({
        from: null,
        to: null
      }),
      garages: this.fb.group({
        from: null,
        to: null
      }),
      area: this.fb.group({
        from: null,
        to: null
      }),
      propertyAge: this.fb.group({
        from: null,
        to: null
      }),
      features: this.buildFeatures()
    });

    this.onSearchChange.emit(this.form);
  }

  public buildFeatures() {
    const arr = this.features.map(feature => {
      return this.fb.group({
        id: feature.id,
        name: feature.name,
        selected: feature.selected
      });
    })
    return this.fb.array(arr);
  }


  ngOnChanges() {
    if (this.removedSearchField) {
      console.log(this.removedSearchField);

      if (this.removedSearchField.indexOf(".") > -1) {
        let arr = this.removedSearchField.split(".");
        this.form.controls[arr[0]]['controls'][arr[1]].reset();
      }
      else if (this.removedSearchField.indexOf(",") > -1) {
        let arr = this.removedSearchField.split(",");
        this.form.controls[arr[0]]['controls'][arr[1]]['controls']['selected'].setValue(false);
      }
      else {
        this.form.controls[this.removedSearchField].reset();
      }
    }
  }

  public reset() {
    this.form.reset({
      propertyType: null,
      propertyStatus: null,
      price: {
        from: null,
        to: null
      },
      country: null,
      city: null,
      zipCode: null,
      street: null,
      bedrooms: {
        from: null,
        to: null
      },
      bathrooms: {
        from: null,
        to: null
      },
      garages: {
        from: null,
        to: null
      },
      area: {
        from: null,
        to: null
      },
      propertyAge: {
        from: null,
        to: null
      },
      features: this.features
    });
  }

  public search() {
    this.onSearchClick.emit();
  }
  public onSelectCountry() {
    var country: CountryDto = this.form.controls['country'].value;
    if (country) {
      this.propertyService.getPropertyCities(country.id).subscribe((data) => {
        this.cities = data;
        this.filteredCities = data.slice();
      });
    }
  }
  public onSelectCity() {
  }
  public getAppearance() {
    return (this.variant != 3) ? 'outline' : '';
  }
  public getFloatLabel() {
    return (this.variant == 1) ? 'always' : '';
  }


}
