using System;

namespace F4B1.Core.Triggerable
{
    public interface ITriggerable
    {
        public void Trigger(float offset);
        public void Trigger(bool ballIsStill);

    }
}