import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeakersessionsComponent } from './speakersessions.component';

describe('SpeakersessionsComponent', () => {
  let component: SpeakersessionsComponent;
  let fixture: ComponentFixture<SpeakersessionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpeakersessionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpeakersessionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
