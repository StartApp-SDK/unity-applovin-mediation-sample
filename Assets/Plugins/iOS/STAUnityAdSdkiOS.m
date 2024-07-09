/*
 Copyright 2019 StartApp Inc
 
 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
 
 http://www.apache.org/licenses/LICENSE-2.0
 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */


#import "STAUnityAdSdkiOS.h"
#import <StartApp/STAStartAppSDK.h>


@implementation STAUnityAdSdkiOS

void sta_setTestAdsEnabled(BOOL enabled) {
    STAStartAppSDK* sdk = [STAStartAppSDK sharedInstance];
    sdk.testAdsEnabled = enabled;
}

@end

