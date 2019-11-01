import { Component, OnInit, ViewChild, HostListener, ViewChildren, QueryList } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { Property } from 'src/app/app.models';
import { SwiperConfigInterface, SwiperDirective } from 'ngx-swiper-wrapper';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { AppSettings, Settings } from 'src/app/app.settings';
import { CompareOverviewComponent } from 'src/app/shared/compare-overview/compare-overview.component';
import { EmbedVideoService } from 'ngx-embed-video';
import { emailValidator } from 'src/app/theme/utils/app-validators';
import { PropertyDto, PhotoDto, ViewUserDto } from 'src/app/shared/services/service.base';
import { PropertyService } from 'src/app/shared/services/property.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit {
  @ViewChild('sidenav', { static: true }) sidenav: any;
  @ViewChildren(SwiperDirective) swipers: QueryList<SwiperDirective>;
  public psConfig: PerfectScrollbarConfigInterface = {
    wheelPropagation: true
  };
  public sidenavOpen: boolean = true;
  public config: SwiperConfigInterface = {};
  public config2: SwiperConfigInterface = {};
  private sub: any;
  //public property: Property;
  public propertyStatus: any[];
  public propertyFeatures: any[];
  public propertyDto: PropertyDto;
  public settings: Settings;
  public embedVideo: any;
  public relatedProperties: Property[];
  public featuredProperties: Property[];
  public agent: ViewUserDto;
  public futureDev: boolean = false;
  public mortgageForm: FormGroup;
  public monthlyPayment: any;
  public contactForm: FormGroup;
  constructor(public appSettings: AppSettings,
    public appService: AppService,
    public router: Router,
    public propertyService: PropertyService,
    private activatedRoute: ActivatedRoute,
    private embedService: EmbedVideoService,
    public fb: FormBuilder) {
    this.settings = this.appSettings.settings;
  }

  ngOnInit() {
    this.sub = this.activatedRoute.params.subscribe(params => {
      this.getPropertyById(params['id']);
    });
    this.getRelatedProperties();
    this.getFeaturedProperties();
    if (window.innerWidth < 960) {
      this.sidenavOpen = false;
      this.sidenav.close();
    };
    this.mortgageForm = this.fb.group({
      principalAmount: ['', Validators.required],
      downPayment: ['', Validators.required],
      interestRate: ['', Validators.required],
      period: ['', Validators.required]
    });
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', Validators.compose([Validators.required, emailValidator])],
      phone: ['', Validators.required],
      message: ['', Validators.required]
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  @HostListener('window:resize')
  public onWindowResize(): void {
    (window.innerWidth < 960) ? this.sidenavOpen = false : this.sidenavOpen = true;
  }

  public getPropertyById(id) {
    this.propertyService.getProperty(id).subscribe(result => {
      if (result) {
        console.log(result);
        this.propertyDto = result;
        this.agent = result.lister;
        if (this.propertyDto.photos.length == 0) {
          environment
          this.propertyDto.photos.push({ url: environment.defaultPropertyImagePath } as PhotoDto);
        }
        this.propertyFeatures = (this.propertyService.FromFeatureDto(result.features, false) as any[]);
        setTimeout(() => {
          this.config.observer = true;
          this.config2.observer = true;
          this.swipers.forEach(swiper => {
            if (swiper) {
              swiper.setIndex(0);
            }
          });
        });
      }
    }, error => {
      this.router.navigate(['not-found']);
    })
    /*   this.appService.getPropertyById(id).subscribe(data => {
        this.property = data;
        this.embedVideo = this.embedService.embed(this.property.videos[1].link);
        setTimeout(() => {
          this.config.observer = true;
          this.config2.observer = true;
          this.swipers.forEach(swiper => {
            if (swiper) {
              swiper.setIndex(0);
            }
          });
        });
      }); */
  }

  ngAfterViewInit() {
    this.config = {
      observer: false,
      slidesPerView: 1,
      spaceBetween: 0,
      keyboard: true,
      navigation: true,
      pagination: false,
      grabCursor: true,
      loop: false,
      preloadImages: false,
      lazy: true,
      autoplay: {
        delay: 5000,
        disableOnInteraction: false
      }
    };

    this.config2 = {
      observer: false,
      slidesPerView: 4,
      spaceBetween: 16,
      keyboard: true,
      navigation: false,
      pagination: false,
      grabCursor: true,
      loop: false,
      preloadImages: false,
      lazy: true,
      breakpoints: {
        480: {
          slidesPerView: 2
        },
        600: {
          slidesPerView: 3,
        }
      }
    }

  }


  public onOpenedChange() {
    this.swipers.forEach(swiper => {
      if (swiper) {
        swiper.update();
      }
    });
  }

  public selectImage(index: number) {
    this.swipers.forEach(swiper => {
      if (swiper['elementRef'].nativeElement.id == 'main-carousel') {
        swiper.setIndex(index);
      }
    });
  }

  public onIndexChange(index: number) {
    this.swipers.forEach(swiper => {
      let elem = swiper['elementRef'].nativeElement;
      if (elem.id == 'small-carousel') {
        swiper.setIndex(index);
        for (let i = 0; i < elem.children[0].children.length; i++) {
          const element = elem.children[0].children[i];
          if (element.classList.contains('thumb-' + index)) {
            element.classList.add('active-thumb');
          }
          else {
            element.classList.remove('active-thumb');
          }
        }
      }
    });
  }

  public addToCompare() {
    // this.appService.addToCompare(this.property, CompareOverviewComponent, (this.settings.rtl) ? 'rtl' : 'ltr');
  }

  public onCompare() {
    //  return this.appService.Data.compareList.filter(item => item.id == this.property.id)[0];
  }

  public addToFavorites() {
    // this.appService.addToFavorites(this.property, (this.settings.rtl) ? 'rtl' : 'ltr');
  }

  public onFavorites() {
    //return this.appService.Data.favorites.filter(item => item.id == this.property.id)[0];
  }

  public getRelatedProperties() {
    this.appService.getRelatedProperties().subscribe(properties => {
      this.relatedProperties = properties;
    })
  }

  public getFeaturedProperties() {
    this.appService.getFeaturedProperties().subscribe(properties => {
      this.featuredProperties = properties.slice(0, 3);
    })
  }

  public getAgent() {
    return this.propertyDto.lister;
  }
  public getPropertyStatus() {
    this.propertyStatus = this.propertyService.getPropertyStatuses();
  }

  public onContactFormSubmit(values: Object) {
    if (this.contactForm.valid) {
      console.log(values);
    }
  }

  public onMortgageFormSubmit(values: Object) {
    if (this.mortgageForm.valid) {
      var principalAmount = values['principalAmount']
      var down = values['downPayment']
      var interest = values['interestRate']
      var term = values['period']
      this.monthlyPayment = this.calculateMortgage(principalAmount, down, interest / 100 / 12, term * 12).toFixed(2);
    }
  }
  public calculateMortgage(principalAmount: any, downPayment: any, interestRate: any, period: any) {
    return ((principalAmount - downPayment) * interestRate) / (1 - Math.pow(1 + interestRate, -period));
  }

}