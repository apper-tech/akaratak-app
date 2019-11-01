import { Component, OnInit, ViewChild, ElementRef, NgZone } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { MapsAPILoader } from '@agm/core';
import { Category, MapResult } from '../../../app.models';
import { Property } from 'src/app/app.models';
import { MatSnackBar } from '@angular/material';
import { PropertyService } from 'src/app/shared/services/property.service';
import { PropertyDto, CountryDto, CityDto } from 'src/app/shared/services/service.base';

@Component({
  selector: 'app-edit-property',
  templateUrl: './edit-property.component.html',
  styleUrls: ['./edit-property.component.scss']
})
export class EditPropertyComponent implements OnInit {
  @ViewChild('addressAutocomplete', { static: false }) addressAutocomplete: ElementRef;
  private sub: any;
  public property: PropertyDto;
  public submitForm: FormGroup;
  public features = [];
  public directions = [];
  public countries: CountryDto[];
  public cities: CityDto[];
  public propertyTypes = [];
  public filteredTypes;
  public filteredCountries;
  public filteredCities;
  public streets = [];
  public lat = 40.678178;
  public lng = -73.944158;
  public zoom = 12;
  constructor(public appService: AppService,
    public propertyService: PropertyService,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.features = this.propertyService.getFeatures();
    this.directions = this.propertyService.getDirections();

    this.propertyService.getPropertyTypes().subscribe((data) => {
      this.propertyTypes = data;
      this.filteredTypes = data.slice();
    });
    this.propertyService.GetCountries().subscribe((data) => {
      this.countries = data;
      this.filteredCountries = data.slice();
    });

    this.submitForm = this.fb.group({
      basic: this.fb.group({
        title: [null, Validators.required],
        desc: null,
        salePrice: null,
        rentPrice: null,
        investPrice: null,
        swap: null,
        propertyType: [null, Validators.required],
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
        balconies: '',
        rooms: '',
        area: '',
        owners: '',
        yearBuilt: '',
        features: this.buildFeatures(),
        directions: this.buildDirections()
      })
    });

    this.placesAutocomplete();

    this.sub = this.activatedRoute.params.subscribe(params => {
      this.getPropertyById(params.id);
    });

  }
  // tslint:disable-next-line: use-lifecycle-interface
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
  public onSelectCountry() {
    const id = this.submitForm.controls.address.get('country').value;
    if (id) {
      this.propertyService.getPropertyCities(id).subscribe((data) => {
        this.cities = data;
        this.filteredCities = data.slice();
        return data;
      });
    }
  }
  public getPropertyById(id) {
    this.propertyService.getProperty(id).subscribe(data => {
      if (data) {
        this.property = data;

        this.submitForm.controls.basic.get('title').setValue(this.property.features.title);
        this.submitForm.controls.basic.get('desc').setValue(this.property.features.description);
        this.submitForm.controls.basic.get('salePrice').setValue(this.property.offer.sale > 0 ? this.property.offer.sale : 0);
        this.submitForm.controls.basic.get('rentPrice').setValue(this.property.offer.rent > 0 ? this.property.offer.rent : 0);
        this.submitForm.controls.basic.get('investPrice').setValue(this.property.offer.invest > 0 ? this.property.offer.invest : 0);
        this.submitForm.controls.basic.get('swap').setValue(this.property.offer.swap);


        this.submitForm.controls.basic.get('propertyType').setValue(this.property.propertyType.id);

        const images: any[] = [];
        this.property.photos.forEach(item => {
          const image = {
            link: item.url,
            preview: item.url
          }
          images.push(image);
        });

        this.submitForm.controls.basic.get('gallery').setValue(images);

        this.submitForm.controls.address.get('location').setValue(this.property.address.location);
        this.submitForm.controls.address.get('zipCode').setValue(this.property.address.zipCode);
        this.submitForm.controls.address.get('street').setValue(this.property.address.street);

        this.lat = this.property.address.latitude;
        this.lng = this.property.address.longitude;

        this.propertyService.getPropertyCities(this.property.address.city.countryId).
          subscribe(cdata => {
            this.cities = cdata;
            this.filteredCities = cdata.slice();
            this.submitForm.controls.address.get('country').setValue(this.property.address.city.countryId);
            this.submitForm.controls.address.get('city').setValue(this.property.address.city.id);
          });

        this.submitForm.controls.additional.get('bedrooms').setValue(this.property.features.bedrooms);
        this.submitForm.controls.additional.get('bathrooms').setValue(this.property.features.bathrooms);
        this.submitForm.controls.additional.get('area').setValue(this.property.features.area);
        this.submitForm.controls.additional.get('owners').setValue(this.property.features.owners);
        this.submitForm.controls.additional.get('balconies').setValue(this.property.features.balconies);
        this.submitForm.controls.additional.get('rooms').setValue(this.property.features.rooms);
        this.submitForm.controls.additional.get('yearBuilt').setValue(this.property.features.propertyAge);

        this.features.forEach(feature => {
          (this.propertyService.FromFeatureDto(this.property.features, false) as any[])
            .forEach(feat => {
              if (feature.name == feat.name) {
                feature.selected = true;
              }
            });
        });
        this.directions.forEach(direction => {
          const direct = this.property.features.direction;
          switch (direction.name.toLowerCase()) {
            case 'south': direction.selected = direct.south; break;
            case 'east': direction.selected = direct.east; break;
            case 'west': direction.selected = direct.west; break;
            case 'north': direction.selected = direct.north; break;
          }
        });
        this.submitForm.controls.additional.get('features').setValue(this.features);
        this.submitForm.controls.additional.get('directions').setValue(this.directions);
      } else {
        this.router.navigate(['not-found']);
      }
    });
  }




  // -------------------- Address ---------------------------  

  public getCurrentSign() {
    return this.property ? this.property.offer.currency.sign : '$';
  }

  private setCurrentPosition() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      });
    }
  }
  private placesAutocomplete() {
    this.mapsAPILoader.load().then(() => {
      const autocomplete = new google.maps.places.Autocomplete(this.addressAutocomplete.nativeElement, {
        types: ['address']
      });
      autocomplete.addListener('place_changed', () => {
        this.ngZone.run(() => {
          const place: google.maps.places.PlaceResult = autocomplete.getPlace();
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
      const address = response.results[0].formatted_address;
      this.submitForm.controls.address.get('location').setValue(address);
      this.setAddresses(response.results);
    })
  }

  public setAddresses(result) {
    const countryCode = (<MapResult>result[0])
      .address_components
      .filter(x => x.types.includes('country'))[0].short_name;
    if (countryCode) {
      const countries = (<CountryDto[]>this.filteredCountries)
        .filter(x => x.code === countryCode);
      this.submitForm.controls.address.get('country')
        .setValue(countries.length > 0 ? countries[0].id : -1);
    }
  }

  public onMapClick(e: any) {
    this.lat = e.coords.lat;
    this.lng = e.coords.lng;
    this.getAddress();
  }
  public onMarkerClick(e: any) {

  }



  // -------------------- Additional ---------------------------  
  public buildFeatures() {
    const arr = this.features.map(feature => {
      return this.fb.group({
        id: feature.id,
        name: feature.name,
        selected: feature.selected
      });
    });
    return this.fb.array(arr);
  }
  public buildDirections() {
    const arr = this.directions.map(direction => {
      return this.fb.group({
        id: direction.id,
        name: direction.name,
        selected: direction.selected
      });
    });
    return this.fb.array(arr);
  }


  // -------------------- Media --------------------------- 
  public createVideo(): FormGroup {
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



  public step = 0;
  setStep(index: number) {
    this.step = index;
  }
  onSubmitForm(form) {
    if (this.submitForm.get(form).valid) {
      this.nextStep();
      if (form == 'additional') {
        this.submitForm.value.id = this.property.id;
        this.submitForm.value.address.lat = this.lat;
        this.submitForm.value.address.lng = this.lng;
        this.submitForm.value.basic.propertyCurrency = this.property.offer.currency.id;
        this.propertyService.updateProperty(this.submitForm.value)
          .then(result => {
            if (result) {
              this.snackBar.open('The property "' + this.property.features.title + '" has been updated.', '×', {
                verticalPosition: 'top',
                duration: 5000
              });
            }
          });
      }
    }
  }
  nextStep() {
    this.step++;
  }
  prevStep() {
    this.step--;
  }



}
