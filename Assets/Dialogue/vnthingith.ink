//Author Sajid Muhtasim
VAR bodyspray = 0
VAR suit = 0
VAR points = 0
VAR game = ""
VAR temproute = true //using this bc idk how to fix the issue i am having
-> main


=== main === 
"Ugh I am so nervous" said MC. "It's my first date with this girl I met the other day in the park, she looked so beautiful under the setting sun." MC looks at the presents he bought. "Let me prepare the gifts I could give her during our date. 
And they are...." *Drum roll*
->Gifts

=== Gifts ===

*[Flowers!] 
    "Well every girl loves flowers right? Maybe. Do I have to worry? Probably not. Right? Yeah it will be fine, surely." ->Gifts 
    
*[Ring!]
    "I got a somewhat expensive ring! Ladies love rings. For a first date I think getting a ring won't be moving too forward. I can't wait to see the look on her face if I decide to give this to her..." ->Gifts

*[Graphics Card!]
    "I have a ZOTAC Gaming GeForce RTX 4090 AMP Extreme AIRO 24GB GDDR6X 384-bit 21 Gbps PCIE 4.0 Graphics Card, IceStorm 3.0 Advanced Cooling, Spectra 2.0 RGB Lighting, ZT-D40900B-10P. I managed to win it off a giveaway that was hosted by this youtuber I watch. Normally I would keep it for myself but I already have one." ->Gifts
* -> main2

=== main2 === 

Packing the gifts, he wonders which would be perfect for her. 

"Okay, I better get ready." Our MC mumbles. "The date is in 3 hours and I can't wait!" 
"What should I wear?"
    *A suit?
        ~suit = 1
        ~ points = points + 1
    *Casual clothes?
    -"This fits my style. I will go with this."
    After putting on his clothes, he looks around to see if he missed anything.
    
"Hmm, do I put some body spray on?" 
    *[Yes]
        "Yeah, let me do that. I wanna make sure I look AND smell as good as possible." 
         ~ points = points + 1
    *[No] 
        "Nah, think I like my natural odor more. I don't wanna be artificial in any way and be as natural as possible."
    -"Okay, let me see." 
  He looks around one last time. "I have done pretty much all I wanted to do to get ready. Let's get going." And with that, our MC heads out to meet his date. 
    
    ->BeginDate
    
    === BeginDate === 
    Our MC arrvies at the date spot. A small water fountain in the park where they had their first fateful encounter. 
    His eyes wanders off to find his date. 
    
    // Speaker 
    "Heyy, I am over here" Our mc turns around to face his date. 
    {suit > 0: "That suit looks really good on you. I love it!" | "You look okay, I guess." }
    "Thank you, you look amazing yourself." Our mc replies. "Have you been waiting long?" 
    "Not really, I got here like a minute ago." Said our MC. "Ready to go?" 
    "Mhm." The girl replies gleefully, and they make their way to the nearest coffee shop.
    
    "So what do you do in your free time?" 
        * I read visual novels mainly
            "Really?" 
            "Yeah" 
            "Which one's your favorite?"
                **[Doki DOki literature club]
                    I actually really liked DDLC, getting all the endings was a thrill for me. 
                **I can't think of one right now.
                -- "I see, I am not that much of a novel reading person" She glances at her wrist watch, then looks back at her coffee.
                
                
        * I play video games.
            "Oh my god really?"
            **"Yeah"
            "What's your favortie video game?" 
                ***COD
                ~ game = "COD"
                ***Valorant
                ~ game ="Valorant"
                ~ points = points + 1
                ***League
                ~ game = "League"
                ***Overwatch
                ~ game = "Overwatch"
                ---"Omg I am actually very into {game} as well! I am so glad we have something in common." 
                
            **"Nah not really."
                "Oh." She seems a little disappointed.
                
        * I like to stare at the stars at night thinking how under the grand scheme of things, we are just beings floating across an endless void of space and time with not much meaning to anything.  
            "Ummm, okay..." She stares blankly.  
             ~ points = points - 1
    - She takes a sip of her coffee. Our MC realizes it's time for him to give the present he has prepared. He is ready to pick one of the three. He chooses....
    ->GiftFinal
    
    === GiftFinal ===
    * Flowers 
        ->FlowerRoute
    * Ring
        -> RingRoute
    *Graphics card
        ->GraphicsRoute
        
        ===FlowerRoute===
        The MC thinks hard for a bit, and then pulls out the flowers he was safely storing in his bag. "This is for you. Someone as pretty as you deserves pretty things." MC hands the flower to the girl with a smirk. He thinks he is the rizzler after a line like that. 
        "Oh thank you. It definitely is pretty." She replies, not amused. The day kept going without much happening, and eventually time passes till it's night time. MC is walking the girl home.
        "This is my place" the girl points at the building. "Thanks for today." 
        *"Did you have a good time?"
            "It was okay. I don't think we are a good match sadly, and you're not that interesting. Sorry. Good luck though"
            "Okay. Thanks." MC replies sighing. The walk back home was a long one that night.
        *"No problem. Stay safe." 
        -And that was the last our mc heard from her. With a heavy heart, he looks forward to what the future holds for him.
        ->END
        
        ===RingRoute===
        The MC thinks hard for a bit, and then pulls out the ring he was safely storing in his bag. "I have something for you," MC shows the ring to the girl. "Here. This isn't an engagement ring by any means. I just think an expensive and amazing ring really suits someone like you!" 
        "Oh my gosh, that's amazing!" The girl cheers. "This is the best gift I have recieved, thank you so much!" 
        Our MC smiles, he feels it was worth getting the somewhat expensive ring. 
        ~ temproute = false
        ->Movies
        
        ===Movies==
        "I am so happy right now. Where do you want to go?" The girl asks. "I kinda wanna watch a movie"
        *"Let's go to the movies." 
            "Yay let's go!" 
        *"Let's take a walk in the park." 
            "Okay but we are going to the movies right after." After walking around for a bit...
        *"Let's go to shopping."
            "Okay, but we are going to the movies right after." After shopping for a bit...
        -They both make it to the movies happily, talking about random things. After getting their tickets to the front row seats, they start watching the movie. After finishing the movie...
         { temproute: -> GraphicsRoute2 | ->RingRoute2}
         
        ===RingRoute2===
    "Hey, I think I need to use the bathroom. Can you wait a bit for me here?" 
        *"Yeah, go ahead." 
        *Sure, take your time" 
        -And with that, time starts ticking. 5 minutes go by.
        30 minutes....
        An hour...
        "Don't think she's coming back." Our MC sighs and makes his way home. Even though the date went okay, he still ended up alone. However, he remains hopeful. He looks forward to what his future holds for him. 
        
        In a computer store, a girl disguised by a hat and a mask can be seen strotting to the store cashier. "This is a very expensive ring. Can I trade this in for a pc? Better give it to me now." 
        
        ->END
        
        ===GraphicsRoute===
        The MC thinks hard for a bit, and then pulls out the graphics card he was safely storing in his bag. "Here this is for you." MC hands her the gift. "It's a graphics card, hopefully you like it." 
        "Omg is this the ZOTAC Gaming GeForce RTX 4090 AMP Extreme AIRO 24GB GDDR6X 384-bit 21 Gbps PCIE 4.0 Graphics Card, IceStorm 3.0 Advanced Cooling, Spectra 2.0 RGB Lighting, ZT-D40900B-10P?? This is eactly what I dreamed of till this day. You have no idea how happy I am!" she exclaims with a huge smile. Our mc thinks to himself, "Okay, turns out she's an egirl." 
        ->Movies
        
        ===GraphicsRoute2===
        She asks our MC to walk her home. "That right there is my home." She points to a small house. "I had a great time today, I am looking forward to going out on more dates with you!" 
        *"Of course! I am also looking forward to it"
        *"I am glad you had a great time. Can't wait to see you again!" 
        -{points < 3:And with that our mc goes back home. "That went way better than I thought." He exclaims as he lays down. With a smile on his face, he looks forward to what the future holds for him. | -> SecretEnding} 
        ->END
        ===SecretEnding===
        And with that our MC goes back home. "That went way better than I thought." He exclaims as he lays down. With a smile on his face, he looks forward to what the future holds for him. Around a year later...
        "I am so lucky to be able to call you my husband. I have been waiting for this day forever." Says the Rose. 
        *"Mhm, I am glad to have you as my kitten for the rest of my life." 
        *"Mhm, I am glad to have you as my wife as well. Forever and ever!" 
        -replies Jack, our MC. And they lived happily ever after.
        
        
        ->END
->END