// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

namespace F4B1.Core.Triggerable
{
    public interface ITriggerable
    {
        public void Trigger(float offset);
        public void Trigger(bool ballIsStill);
    }
}