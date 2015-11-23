/******************************************************************************
 * Spine Runtimes Software License
 * Version 2.3
 * 
 * Copyright (c) 2013-2015, Esoteric Software
 * All rights reserved.
 * 
 * You are granted a perpetual, non-exclusive, non-sublicensable and
 * non-transferable license to use, install, execute and perform the Spine
 * Runtimes Software (the "Software") and derivative works solely for personal
 * or internal use. Without the written permission of Esoteric Software (see
 * Section 2 of the Spine Software License Agreement), you may not (a) modify,
 * translate, adapt or otherwise create derivative works, improvements of the
 * Software or develop new applications using the Software or (b) remove,
 * delete, alter or obscure any trademarks or any copyright, trademark, patent
 * or other intellectual property or proprietary rights notices on or in the
 * Software, including any copy thereof. Redistributions in binary or source
 * form must include this license and terms.
 * 
 * THIS SOFTWARE IS PROVIDED BY ESOTERIC SOFTWARE "AS IS" AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
 * EVENT SHALL ESOTERIC SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

using UnityEngine;
using System.Collections;
using Spine;
using System;

public class Spineboy : MonoBehaviour {
	SkeletonAnimation skeletonAnimation;

	public void Start () {
		// Get the SkeletonAnimation component for the GameObject this script is attached to.
		skeletonAnimation = GetComponent<SkeletonAnimation>();

		// Call our method any time an animation fires an event.
		//skeletonAnimation.state.Event += Event;
		skeletonAnimation.state.Event += (state, trackIndex, e ) => {
			Debug.Log( trackIndex + " " + state.GetCurrent( trackIndex ) + ": event " + e.Data.Name + ", " + e.Int );
		};


		// A lambda can be used for the callback instead of a method.
		skeletonAnimation.state.End += (state, trackIndex) => {
			Debug.Log("start: " + state.GetCurrent(trackIndex));
		};
		// Queue jump to be played on track 0 two seconds after the starting animation.
		skeletonAnimation.state.AddAnimation(0, "jump", false, 2);
		// Queue walk to be looped on track 0 after the jump animation.
		skeletonAnimation.state.AddAnimation(0, "run", true, 0);
	}
	
	public void Event (Spine.AnimationState state, int trackIndex, Spine.Event e) {
		Debug.Log(trackIndex + " " + state.GetCurrent(trackIndex) + ": event " + e.Data.Name + ", " + e.Int);
	}

	public void OnMouseDown () {
		// Set jump to be played on track 0 immediately.
		skeletonAnimation.state.SetAnimation( 0, "jump", false);
		skeletonAnimation.state.AddAnimation( 1, "shoot", true, 0 );
		// Queue walk to be looped on track 0 after the jump animation.
		skeletonAnimation.state.AddAnimation(0, "run", true, 0);
	}
	public void OnMouseUp()
	{
		skeletonAnimation.state.SetAnimation( 1, "shoot", false );
	}
}