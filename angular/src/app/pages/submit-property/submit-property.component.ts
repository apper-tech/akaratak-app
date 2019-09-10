/// <reference types="@types/googlemaps" />
import { Component, OnInit, ViewChild, ElementRef, NgZone } from '@angular/core';
import { MatStepper } from '@angular/material';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { AppService } from 'src/app/app.service';
import { PropertyService } from 'src/app/shared/services/property.service';
import { MapResult, MapAddressComponent } from '../../app.models';
import { MapsAPILoader } from '@agm/core';
import { CurrencyDto, CategoryDto, TagDto, CountryDto, CityDto } from 'src/app/shared/services/service.base';

@Component({
  selector: 'app-submit-property',
  templateUrl: './submit-property.component.html',
  styleUrls: ['./submit-property.component.scss']
})
export class SubmitPropertyComponent implements OnInit {
  @ViewChild('horizontalStepper', { static: true }) horizontalStepper: MatStepper;
  @ViewChild('addressAutocomplete', { static: false }) addressAutocomplete: ElementRef;
  public submitForm: FormGroup;
  public features = [];
  public directions = [];
  public propertyTypes: CategoryDto[];
  public propertyTags: TagDto[];
  public countries: CountryDto[];
  public cities: CityDto[];
  public propertyCurrencies: CurrencyDto[];
  public propertyStatuses = [];
  public lat: number = 40.678178;
  public lng: number = -73.944158;
  public zoom: number = 12;
  public filteredCurrencies;
  public filteredTypes;
  public filteredTags;
  public filteredCountries;
  public filteredCities;
  public propertyStatusTypes = {
    sale: false,
    rent: false,
    invest: false,
    swapp: false
  };
  public submited: any;
  constructor(public appService: AppService,
    public propertyService: PropertyService,
    private fb: FormBuilder,
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone) { }

  ngOnInit() {
    this.features = this.propertyService.getFeatures();
    this.directions = this.propertyService.getDirections();

    this.propertyService.getPropertyTypes().subscribe((data) => {
      this.propertyTypes = data;
      this.filteredTypes = data.slice();
    });
    this.propertyService.getCurrencies().subscribe((data) => {
      this.propertyCurrencies = data;
      this.filteredCurrencies = data.slice();
    });
    this.propertyService.getPropertyTags().subscribe((data) => {
      this.propertyTags = data;
      this.filteredTags = data.slice();
    });
    this.propertyService.GetCountries().subscribe((data) => {
      this.countries = data;
      this.filteredCountries = data.slice();
    });
    this.propertyStatuses = this.appService.getPropertyStatuses();
    this.submitForm = this.fb.group({
      basic: this.fb.group({
        title: [null, Validators.required],
        desc: [null, Validators.required],
        salePrice: null,
        rentPrice: null,
        investPrice: null,
        propertyType: [null, Validators.required],
        propertyCurrency: [null, Validators.required],
        propertyStatus: null,
        propertyTags: null,
        gallery: null
      }),
      address: this.fb.group({
        location: ['', Validators.required],
        country: ['', Validators.required],
        city: ['', Validators.required],
        zipCode: '',
        street: ''
      }),
      additional: this.fb.group({
        bedrooms: '',
        bathrooms: '',
        rooms: '',
        balconies: '',
        area: '',
        owners: '',
        yearBuilt: '',
        features: this.buildFeatures(),
        directions: this.buildDirections()
      }),
      /*  media: this.fb.group({
         videos: this.fb.array([this.createVideo()]),
         plans: this.fb.array([this.createPlan()]),
         additionalFeatures: this.fb.array([this.createFeature()]),
         featured: false
       }) */
    });

    this.setCurrentPosition();
    this.placesAutocomplete();
  }


  public onSelectionChange(e: any) {
    if (e.selectedIndex == 4) {
      this.horizontalStepper._steps.forEach(step => step.editable = false);
      console.log(this.submitForm.value);
    }
  }
  public log() {
    console.log(this.submitForm);
  }
  public submit() {
    this.submitForm.value['address']['lat'] = this.lat;
    this.submitForm.value['address']['lng'] = this.lng;

    this.propertyService.submitProperty(this.submitForm.value).subscribe(result => this.submited);
  }
  public getCurrentSign() {
    if (this.submitForm.get('basic')['controls'].propertyCurrency.value) {
      var currency = this.propertyCurrencies
        .find(item => item.id == this.submitForm.get('basic')['controls'].propertyCurrency.value);
      return currency.localSign;
    }
  }
  public propertyStatusChange(e) {
    var basic = this.submitForm.controls['basic'].value;
    this.propertyStatusTypes.sale = false;
    this.propertyStatusTypes.rent = false;
    this.propertyStatusTypes.invest = false;
    basic.propertyStatus.forEach(element => {
      switch (element.id) {
        case 1:
          this.propertyStatusTypes.sale = true;
          break;
        case 2:
          this.propertyStatusTypes.rent = true;
          break;
        case 3:
          this.propertyStatusTypes.invest = true;
          break;
      }
    });

  }
  public reset() {
    this.horizontalStepper.reset();

    const videos = <FormArray>this.submitForm.controls.media.get('videos');
    while (videos.length > 1) {
      videos.removeAt(0)
    }
    const plans = <FormArray>this.submitForm.controls.media.get('plans');
    while (plans.length > 1) {
      plans.removeAt(0)
    }
    const additionalFeatures = <FormArray>this.submitForm.controls.media.get('additionalFeatures');
    while (additionalFeatures.length > 1) {
      additionalFeatures.removeAt(0)
    }

    this.submitForm.reset({
      additional: {
        features: this.features
      },
      /*   media: {
          featured: false
        } */
    });

  }



  // -------------------- Address ---------------------------  
  public onSelectCountry() {
    var id = this.submitForm.controls.address.get('country').value;
    if (id) {
      this.propertyService.getPropertyCities(id).subscribe((data) => {
        this.cities = data;
        this.filteredCities = data.slice();
        return data;
      });
    }
  }
  public onSelectNeighborhood() {
    this.submitForm.controls.address.get('street').setValue(null, { emitEvent: false });
  }

  private setCurrentPosition() {
    if ("geolocation" in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      });
    }
  }
  private placesAutocomplete() {
    this.mapsAPILoader.load().then(() => {
      let autocomplete = new google.maps.places.Autocomplete(this.addressAutocomplete.nativeElement, {
        types: ["address"]
      });
      autocomplete.addListener("place_changed", () => {
        this.ngZone.run(() => {
          let place: google.maps.places.PlaceResult = autocomplete.getPlace();
          if (place.geometry === undefined || place.geometry === null) {
            return;
          };
          this.lat = place.geometry.location.lat();
          this.lng = place.geometry.location.lng();
          this.getAddress();
        });
      });
    });
  }
  public getAddress() {
    this.appService.getAddress(this.lat, this.lng).subscribe(response => {
      console.log(response);
      let address = response['results'][0].formatted_address;
      this.submitForm.controls.address.get('location').setValue(address);
      this.setAddresses(response['results']);
    })
  }
  public onMapClick(e: any) {
    this.lat = e.coords.lat;
    this.lng = e.coords.lng;
    this.getAddress();
  }
  public onMarkerClick(e: any) {
    console.log(e);
  }

  public setAddresses(result) {
    var countryCode = (<MapResult>result[0])
      .address_components
      .filter(x => x.types.includes('country'))[0].short_name;
    if (countryCode) {
      var countries = (<CountryDto[]>this.filteredCountries)
        .filter(x => x.code === countryCode);
      this.submitForm.controls.address.get('country')
        .setValue(countries.length > 0 ? countries[0].id : -1);
    }




    this.propertyService
      .getPropertyCities(this.submitForm.controls.address.get('country').value)
      .subscribe((data) => {
        this.cities = data;
        this.filteredCities = data.slice();

        var cityName = (<MapResult>result[1])
          .address_components
          .filter(x => x.types.includes('political'))[0].short_name;

        if (cityName) {
          var cities = (<CityDto[]>this.filteredCities)
            .filter(x => x.name === cityName);

          this.submitForm.controls.address.get('city')
            .setValue(cities.length > 0 ? cities[0].id : -1);
        }
      });
  }




  // -------------------- Additional ---------------------------  
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
  public buildDirections() {
    const arr = this.directions.map(direction => {
      return this.fb.group({
        id: direction.id,
        name: direction.name,
        selected: direction.selected
      });
    })
    return this.fb.array(arr);
  }



  // -------------------- Media --------------------------- 
  /* public createVideo(): FormGroup {
    return this.fb.group({
      id: null,
      name: null,
      link: null
    });
  }
  public addVideo(): void {
    const videos = this.submitForm.controls.media.get('videos') as FormArray;
    videos.push(this.createVideo());
  }
  public deleteVideo(index) {
    const videos = this.submitForm.controls.media.get('videos') as FormArray;
    videos.removeAt(index);
  }

  public createPlan(): FormGroup {
    return this.fb.group({
      id: null,
      name: null,
      desc: null,
      area: null,
      rooms: null,
      baths: null,
      image: null
    });
  }
  public addPlan(): void {
    const plans = this.submitForm.controls.media.get('plans') as FormArray;
    plans.push(this.createPlan());
  }
  public deletePlan(index) {
    const plans = this.submitForm.controls.media.get('plans') as FormArray;
    plans.removeAt(index);
  }


  public createFeature(): FormGroup {
    return this.fb.group({
      id: null,
      name: null,
      value: null
    });
  }
  public addFeature(): void {
    const features = this.submitForm.controls.media.get('additionalFeatures') as FormArray;
    features.push(this.createFeature());
  }
  public deleteFeature(index) {
    const features = this.submitForm.controls.media.get('additionalFeatures') as FormArray;
    features.removeAt(index);
  }
 */

}